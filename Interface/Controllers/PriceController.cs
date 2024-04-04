using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Service.Interface;
using Interface.Data;
using Interface.Models.Price;
using Interface.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Utility;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Interface.Controllers
{
	public class PriceController : Controller
	{
		private readonly IPriceService _priceService;
		private readonly ISettingService _settingService;
		private readonly IMapper _mapper;
		private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

		//  private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
		private readonly UserManager<ApplicationUser> UserManager;

		private readonly RoleManager<ApplicationRole> _roleManager;

		public PriceController(IPriceService _priceService, IRolePermisionService rolePermision, UserManager<ApplicationUser> UManager,
			IRazorViewToStringRenderer razorViewToStringRenderer, IMapper mapper, RoleManager<ApplicationRole> roleManager,
			ISettingService settingService)
		{
			this._priceService = _priceService;

			this._mapper = mapper;
			this._settingService = settingService;
			this._razorViewToStringRenderer = razorViewToStringRenderer;
			this.UserManager = UManager;
			_roleManager = roleManager;
		}

		// GET: Price
		//    //[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public async Task<ActionResult> Index(string id = "")
		{
			//var access = false;
			//if (User.Identity.IsAuthenticated)
			//{
			//	id = UserManager.GetUserId(User); ;
			//	var currentUser = await UserManager.FindByIdAsync(id);
			//	if (User.IsInRole("sysAdmin") | User.IsInRole("Administrator") | User.IsInRole("Management") | User.IsInRole("Sales"))
			//		access = true;
			//}
			//else
			//{
			//	var currentUser = await UserManager.FindByIdAsync(id);
			//	if (await UserManager.IsInRoleAsync(currentUser, "sysAdmin") | await UserManager.IsInRoleAsync(currentUser, "Administrator") | await UserManager.IsInRoleAsync(currentUser, "Management") | await UserManager.IsInRoleAsync(currentUser, "Sales"))
			//		access = true;
			//}
			//if (!access)
			//	return RedirectToAction("Index", "Admin");

			var model = new PriceViewModel();
			model.ListGlassType = _priceService.ListAllGlassTypes();
			var firstGlassTypeId = model.ListGlassType.FirstOrDefault()?.ID ?? 0;

			var listOptions = _priceService.ListGlassOptionByTypeID(firstGlassTypeId);
			var listThikness = _priceService.ListGlassThicknesByTypeID(firstGlassTypeId);
			var listStrength = _priceService.ListGlassStrengthByTypeID(firstGlassTypeId);
			var listEdge = _priceService.ListAllFabrication().Where(p => p.FabricationCategory.Title == "Edgework").ToList();
			model.FabricationList = _priceService.ListAllFabrication().Where(p => p.FabricationCategory.Title != "Edgework").OrderByDescending(p => p.FabricationCategoryID == 2004).ThenBy(p => p.FabricationCategoryID).ToList();
			var listGlassFab = _priceService.ListGLassFabricationByTypeID(firstGlassTypeId);
			model.FabricationList = (from gf in listGlassFab
									 join f in model.FabricationList on gf.FabricationID equals f.ID
									 where gf.GlassTypeID == firstGlassTypeId
									 select f).ToList();

			ViewBag.ListItemArray = model.FabricationList.Select(p => p.ID).ToArray();

			try
			{
				var firstThicknes = listThikness.FirstOrDefault().ID;
				listEdge[0].PerUnit = _priceService.FabricationPriceValue(listEdge[0].ID, firstThicknes, 0, firstGlassTypeId, model.GlassStrengthID);
				foreach (var item in model.FabricationList)
				{
					item.PerUnit = _priceService.FabricationPriceValue(item.ID, firstThicknes, 0, firstGlassTypeId, model.GlassStrengthID);
				}
				model.GlassPricePerunit = _priceService.GetGlassPrice(listThikness.FirstOrDefault().ID, listStrength.FirstOrDefault().ID, listOptions.FirstOrDefault().ID, firstGlassTypeId);
			}
			catch { }

			ViewBag.ListGlassStrength = listStrength;
			ViewBag.ListGlassThicknes = listThikness;
			ViewBag.ListGlassOption = listOptions;
			model.ListEdgeWork = listEdge;
			ViewBag.ListExtra = _priceService.ListExtraPrice();
			try
			{
				var setting = _settingService.DefaultSetting();
				model.UnitFuleSurcharge = setting.UnitFuleSurcharge;
				model.CreditCardFee = setting.CreditCardFee;
				model.BenefitsPercentage = setting.BenefitsPercentage;
			}
			catch { }
			return View(model);
			//return View();
		}

		// //[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public ActionResult _getGlassPrice(int StrengthID = 0, int ThicknesID = 0, int OptionID = 0, int TypeID = 0)
		{
			try
			{
				var price = _priceService.GetGlassPrice(ThicknesID, StrengthID, OptionID, TypeID);
				return Json(new { success = true, price = price });
			}
			catch (Exception)
			{
				return Json(new { success = false, price = -2 });
			}
		}

		//   //[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public ActionResult _savGlassPrice(int StrengthID = 0, int ThicknesID = 0, int OptionID = 0, int TypeID = 0, double price = 0)
		{
			try
			{
				if (_priceService.AddOrUpdate(ThicknesID, StrengthID, OptionID, TypeID, price))
					return Json(new { success = true });
				else
					return Json(new { success = false });
			}
			catch (Exception)
			{
				return Json(new { success = false, price = -2 });
			}
		}

		[HttpGet]
		////[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public ActionResult _editEdgePrice(int fid, int ThicknesID, int GlassTypeID = 1, double Square = 0, string id = "", int StrengthID = 0)
		{
			var model = new FabricationPriceModel();
			model.FabricationID = fid;
			model.GlassThicknesID = ThicknesID;
			model.htmlID = id;
			model.GlassTypeID = GlassTypeID;
			model.GlassStrengthID = StrengthID;
			var fab = _priceService.FabricationPriceDetail(fid, ThicknesID, GetSquareFormat(GlassTypeID, Square), GlassTypeID, StrengthID);
			if (fab != null) model.Price = fab.Price;
			model.Sqf25 = GetSquareFormat(GlassTypeID, Square);
			return PartialView(model);
		}

		[HttpGet]
		//    //[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public ActionResult _loadedgeprice(int fid, int ThicknesID, double Square = 0, int GlassTypeID = 0, int StrengthID = 0)
		{
			var fab = _priceService.FabricationPriceDetail(fid, ThicknesID, GetSquareFormat(GlassTypeID, Square), GlassTypeID, StrengthID);

			return Json(new { success = false, price = fab?.Price ?? 0 });
		}

		[HttpPost]
		// //[CustomAuthorize("Price", ActionType.Write)]
		[AllowAnonymous]
		public async Task<ActionResult> _editEdgePrice(FabricationPriceModel item)
		{
			var model = new FabricationPriceEnt();
			model.FabricationID = item.FabricationID;
			model.GlassThicknesID = item.GlassThicknesID;
			model.GlassStrengthID = item.GlassStrengthID;
			model.Sqf25 = item.Sqf25;
			model.Price = item.Price;
			model.GlassTypeID = item.GlassTypeID;

			if (_priceService.AddOrUpdateFabricationPrice(model))
				return Json(new { success = true });
			else

				return Json(new { success = false, responseText = "Error... please try again" });
		}

		//Delete record in jquery grid
		[HttpPost]
		// //[CustomAuthorize("Price", ActionType.Read)]
		[AllowAnonymous]
		public async Task<ActionResult> _glassTypeChange(int id = 0, int ThicknesID = 0, int StrengthID = 0, double Square = 0)
		{
			try
			{
				var model = new PriceViewModel();
				model.GlassThicknesID = ThicknesID;
				model.GlassStrengthID = StrengthID;
				var listOptions = _priceService.ListGlassOptionByTypeID(id);
				var listThikness = _priceService.ListGlassThicknesByTypeID(id);
				var listStrength = _priceService.ListGlassStrengthByTypeID(id);
				var listEdge = _priceService.ListAllFabrication().Where(p => p.FabricationCategory.Title == "Edgework").ToList();
				model.FabricationList = _priceService.ListAllFabrication().Where(p => p.FabricationCategory.Title != "Edgework").ToList();

				var listGlassFab = _priceService.ListGLassFabricationByTypeID(id);
				model.FabricationList = (from gf in listGlassFab
										 join f in model.FabricationList on gf.FabricationID equals f.ID
										 where gf.GlassTypeID == id
										 select f).ToList();

				if (id == 3)
					model.FabricationList = model.FabricationList.OrderByDescending(p => p.FabricationCategoryID).ToList();

				ViewBag.ListItemArray = model.FabricationList.Select(p => p.ID).ToArray();

				try
				{
					var firstThicknes = ThicknesID != 0 ? ThicknesID : listThikness.FirstOrDefault().ID;
					listEdge[0].PerUnit = _priceService.FabricationPriceValue(listEdge[0].ID, firstThicknes, GetSquareFormat(id, Square), id, StrengthID);
					foreach (var item in model.FabricationList)
					{
						item.PerUnit = _priceService.FabricationPriceValue(item.ID, firstThicknes, GetSquareFormat(id, Square), id, StrengthID);
					}
					model.GlassPricePerunit = _priceService.GetGlassPrice(firstThicknes, listStrength.FirstOrDefault().ID, listOptions.FirstOrDefault().ID, id);
				}
				catch { }

				ViewBag.ListGlassStrength = listStrength;
				ViewBag.ListGlassThicknes = listThikness;
				ViewBag.ListGlassOption = listOptions;
				model.ListEdgeWork = listEdge;

				try
				{
					var setting = _settingService.DefaultSetting();
					model.UnitFuleSurcharge = setting.UnitFuleSurcharge;
					model.CreditCardFee = setting.CreditCardFee;
					model.BenefitsPercentage = setting.BenefitsPercentage;
				}
				catch { }
				return Json(new JsonData()
				{
					success = true,
					html = await _razorViewToStringRenderer.RenderViewToStringAsync("_glassTypeChange", model)
				});
			}
			catch (Exception ex)
			{
				return Json(new { success = false, responseText = "Error... Please try again.", error = ex.ToString() });
			}
		}

		[AllowAnonymous]
		private byte GetSquareFormat(int id, double Square)
		{
			byte res = 0;
			if (id == 1 | id == 3)
				res = 0;
			if (id == 2)
			{
				if (Square <= 25)
					res = 1;
				else
					res = 2;
			}
			return res;
		}

		#region ExtraPrice

		//load index of entity
		[CustomAuthorize("PriceConfig", ActionType.Add)]
		public ActionResult ExtraPrice()
		{
			return View();
		}

		//Return list of model to jqueryGRid
		[CustomAuthorize("PriceConfig", ActionType.Read)]
		public ActionResult _ExtraPriceList(string Search = "")
		{
			var ExtraPrice = _priceService.ListExtraPrice().ToList();

			ExtraPrice = ExtraPrice.Where(p =>
			((p.Title ?? "").ToString().ToLower().Contains(Search.ToLower()))
			).ToList();
			return Json(ExtraPrice);
		}

		//Delete record in jquery grid
		[CustomAuthorize("PriceConfig", ActionType.Read)]
		public ActionResult deleteExtraPrice(int id)
		{
			try
			{
				if (_priceService.DeleteExtraPrice(id))
				{
					return Json(new { success = true, responseText = "Data deleted successfully" });
				}
				else
				{
					return Json(new { success = false, responseText = "Error... Please try again" });
				}
			}
			catch (Exception ex)
			{
				return Json(new { success = false, responseText = "Error... Please try again.", error = ex.ToString() });
			}
		}

		[HttpGet]
		[CustomAuthorize("PriceConfig", ActionType.Read)]
		public ActionResult _ExtraPrice(int id = 0)
		{
			ViewBag.mode = (id == 0) ? "add" : "edit";
			if (id == 0)
			{
				return PartialView(new GlassExtraPriceEnt());
			}
			else
			{
				var ExtraPrice = _priceService.ExtraPriceDetails(id);
				return PartialView(ExtraPrice);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[CustomAuthorize("PriceConfig", ActionType.Write)]
		public ActionResult _ExtraPrice(GlassExtraPriceEnt model, string mode)
		{
			try
			{
				ViewBag.mode = mode;

				if (_priceService.IFExistExtraPriceTitle(model.Title, model.ID))
				{
					return Json(new { success = false, responseText = "ExtraPrice Title is exist" });
				}

				if (string.IsNullOrWhiteSpace(model.Title))
				{
					return Json(new { success = false, responseText = "The field Title is required" });
				}

				if (model.ID == 0)
				{
					if (!_priceService.AddExtraPrice(model))
					{
						return Json(new { success = false, responseText = "Error... Please try again" });
					}
				}
				else
				{
					if (!_priceService.EditExtraPrice(model))
					{
						return Json(new { success = false, responseText = "Error... Please try again" });
					}
				}

				return Json(new { success = true, responseText = "Data saved successfully." });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, responseText = GetErrorListFromModelState(ModelState, ex.Message) });
			}
		}

		#endregion ExtraPrice

		#region Function

		public string GetErrorListFromModelState(ModelStateDictionary modelState, string exMessage = "")
		{
			var query = from state in modelState.Values
						from error in state.Errors
						select error.ErrorMessage;

			foreach (var item in query)
			{
				TempData["Message"] += item + "<br /> ";
			}

			return TempData["Message"] == null ? exMessage :
				TempData["Message"].ToString() + "<p >" + exMessage + "</p>";
		}

		public string GetErrorListFromModelState(ModelStateDictionary modelState)
		{
			var query = from state in modelState.Values
						from error in state.Errors
						select error.ErrorMessage;

			var Msg = "";
			foreach (var item in query)
			{
				Msg += item + "<br />";
			}

			return Msg;
		}

		#endregion Function
	}
}