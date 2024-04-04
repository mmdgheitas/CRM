using Interface.Models.Price;
using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNet.Identity;
using Infrastructure.Entity.newAdded;

namespace Interface.Controllers
{
    public class newAddedController : Controller
    {
        private readonly IPriceService _priceService;
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        //newAdded
        private readonly InewAddedService _newAddedService;

        public newAddedController(IPriceService _priceService, IRolePermisionService rolePermision,
            IRazorViewToStringRenderer razorViewToStringRenderer, IMapper mapper,
            ISettingService settingService, InewAddedService _newAddedService)
        {
            this._priceService = _priceService;
            this._mapper = mapper;
            this._settingService = settingService;
            this._razorViewToStringRenderer = razorViewToStringRenderer;

            //newAdded
            this._newAddedService = _newAddedService;
        }

        public IActionResult Index(double? width, double? height, string? glassType, string? frameType, int elevation)
        {
            var model = new PriceViewModel();
            model.ListGlassType = _priceService.ListAllGlassTypes().OrderBy(i => i.Priority).ToList();

            //newAdded
            model.ListnewGlassType = _newAddedService.ListAllnewGlassTypes().OrderBy(i => i.Priority).ToList();
            model.ListnewFrameType = _newAddedService.ListAllnewFrameTypes().OrderBy(i => i.Value).ToList();

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

            try
            {
                ViewBag.squareFoot = width != null && height != null ? (width * height) / 144 : null;
                ViewBag.squareFoot = Math.Round(ViewBag.squareFoot, 2);
                ViewBag.minimumThicknes = listThikness.FirstOrDefault()?.Value ?? 0;

                ViewBag.glssLib = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.lib ?? 0;
                ViewBag.glassPerUnit = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.perUnit ?? 0;

                ViewBag.glassPrise = ViewBag.glassPerUnit * ViewBag.squareFoot;
                ViewBag.glassPrise = Math.Round(ViewBag.glassPrise, 2);

                ViewBag.hours = model.ListnewFrameType.Where(i => i.Title == frameType).SingleOrDefault()?.Value ?? 0;

                double totalLib = (ViewBag.glssLib + model.ListnewFrameType.Where(i => i.Title == frameType).SingleOrDefault()?.lib) / 11;

                if (elevation <= 10)
                {
                    ViewBag.installers = 1;
                }
                else
                {
                    if (elevation > 10 && elevation < 20 && totalLib > 10 && totalLib < 20)
                    {
                        ViewBag.installers = 2;
                    }
                    if (elevation > 20 && elevation < 30 && totalLib > 20 && totalLib < 30)
                    {
                        ViewBag.installers = 3;
                    }
                    if (elevation > 30 && elevation < 40 && totalLib > 30 && totalLib < 40)
                    {
                        ViewBag.installers = 4;
                    }
                    else
                    {
                        ViewBag.installers = 5;
                    }
                }

                model.FinalPrice = ViewBag.glassPrise + (ViewBag.hours + ViewBag.installers) * 100;
            }
            catch { }

            return View(model);
            //return View();
        }
    }
}