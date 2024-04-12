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
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Stimulsoft.System.Windows.Forms;
using System;

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

        private List<int[]> lidInfos = new List<int[]>
        {
            new int[] {1, 4, 80, 20, 1 },
            new int[] { 2, 4, 160, 40, 2 },
            new int[] { 3, 4, 240, 40, 3 },
            new int[] { 4, 4, 320, 50, 4 },
            new int[] {5, 8, 40, 10, 1 },
            new int[] { 6, 8, 80, 20, 2 },
            new int[] { 7, 8, 120, 40, 3 },
            new int[] { 8, 16, 40, 10, 2 },
            new int[] { 9, 16, 80, 20, 3 },
            new int[] { 10, 16, 120, 40, 4 },
            new int[] { 11, 24, 40, 10, 2 },
            new int[] { 12, 24, 80, 20, 3 },
            new int[] { 13, 24, 120, 40, 4 },
        };

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

            List<SelectListItem> listitems = new List<SelectListItem>();
            foreach (newFrameType c in model.ListnewFrameType)
            {
                listitems.Add(new SelectListItem
                {
                    Value = c.Value.ToString(),
                    Text = c.Title.ToString()
                });
            }
            ViewBag.ListItems = listitems;

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
                ViewBag.minimumThicknes = "1/8";
                if (ViewBag.squareFoot <= 20)
                {
                    ViewBag.minimumThicknes = "1/8";
                }
                if (ViewBag.squareFoot >= 20 && ViewBag.squareFoot <= 25)
                {
                    ViewBag.minimumThicknes = "5/32";
                }
                if (ViewBag.squareFoot >= 25 && ViewBag.squareFoot <= 40)
                {
                    ViewBag.minimumThicknes = "3/16";
                }
                if (ViewBag.squareFoot >= 40)
                {
                    ViewBag.minimumThicknes = "1/4";
                }

                ViewBag.glssLib = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.lib ?? 0;
                ViewBag.glassPerUnit = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.perUnit ?? 0;

                ViewBag.glassPrise = ViewBag.glassPerUnit * ViewBag.squareFoot;
                ViewBag.glassPrise = Math.Round(ViewBag.glassPrise, 2);

                ViewBag.hours = model.ListnewFrameType.Where(i => i.Title == frameType).SingleOrDefault()?.Value ?? 0;

                int[] installers = { 0 };
                int id = 0;
                foreach (var lid in lidInfos)
                {
                    if (elevation <= lid[1] && ViewBag.glssLib >= lid[2] && ViewBag.squareFoot >= lid[3])
                    {
                        id = lid[0];
                        installers = installers.Append(lid[4]).ToArray();
                    }
                    else
                    {
                        // If no suitable match is found
                        installers = installers.Append(-1).ToArray();
                    }
                }
                ViewBag.installers = installers.Max();

                model.FinalPrice = ViewBag.glassPrise + (ViewBag.hours + ViewBag.installers) * 100;
            }
            catch { }

            return View(model);
            //return View();
        }

        public PriceViewModel calculate(double? width, double? height, string? glassType, string? frameType, int elevation)
        {
            var model = new PriceViewModel();
            model.ListGlassType = _priceService.ListAllGlassTypes().OrderBy(i => i.Priority).ToList();

            //newAdded
            model.ListnewGlassType = _newAddedService.ListAllnewGlassTypes().OrderBy(i => i.Priority).ToList();
            model.ListnewFrameType = _newAddedService.ListAllnewFrameTypes().OrderBy(i => i.Value).ToList();

            List<SelectListItem> listitems = new List<SelectListItem>();
            foreach (newFrameType c in model.ListnewFrameType)
            {
                listitems.Add(new SelectListItem
                {
                    Value = c.Value.ToString(),
                    Text = c.Title.ToString()
                });
            }
            ViewBag.ListItems = listitems;

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
                ViewBag.minimumThicknes = "1/8";
                if (ViewBag.squareFoot <= 20)
                {
                    ViewBag.minimumThicknes = "1/8";
                }
                if (ViewBag.squareFoot >= 20 && ViewBag.squareFoot <= 25)
                {
                    ViewBag.minimumThicknes = "5/32";
                }
                if (ViewBag.squareFoot >= 25 && ViewBag.squareFoot <= 40)
                {
                    ViewBag.minimumThicknes = "3/16";
                }
                if (ViewBag.squareFoot >= 40)
                {
                    ViewBag.minimumThicknes = "1/4";
                }

                ViewBag.glssLib = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.lib ?? 0;
                ViewBag.glassPerUnit = model.ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.perUnit ?? 0;

                ViewBag.glassPrise = ViewBag.glassPerUnit * ViewBag.squareFoot;
                ViewBag.glassPrise = Math.Round(ViewBag.glassPrise, 2);

                ViewBag.hours = model.ListnewFrameType.Where(i => i.Title == frameType).SingleOrDefault()?.Value ?? 0;

                int[] installers = { 0 };
                int id = 0;
                foreach (var lid in lidInfos)
                {
                    if (elevation <= lid[1] && ViewBag.glssLib >= lid[2] && ViewBag.squareFoot >= lid[3])
                    {
                        id = lid[0];
                        installers = installers.Append(lid[4]).ToArray();
                    }
                    else
                    {
                        // If no suitable match is found
                        installers = installers.Append(-1).ToArray();
                    }
                }
                ViewBag.installers = installers.Max();

                model.FinalPrice = ViewBag.glassPrise + (ViewBag.hours + ViewBag.installers) * 100;
            }
            catch { }

            return model;
            //return View();
        }

        public string[] calculateSquareFoot(double width, double height)
        {
            double squareFoot = (width * height) / 144;
            squareFoot = Math.Round(squareFoot, 2);
            string minimumThicknes = "1/8";
            if (squareFoot <= 20)
            {
                minimumThicknes = "1/8";
            }
            if (squareFoot >= 20 && squareFoot <= 25)
            {
                minimumThicknes = "5/32";
            }
            if (squareFoot >= 25 && squareFoot <= 40)
            {
                minimumThicknes = "3/16";
            }
            if (squareFoot >= 40)
            {
                minimumThicknes = "1/4";
            }

            string[] data = { squareFoot.ToString(), minimumThicknes };
            return data;
        }

        public double[] calculateGlassType(string squareFootInput, string glassType)
        {
            List<newGlassType> ListnewGlassType = _newAddedService.ListAllnewGlassTypes().OrderBy(i => i.Priority).ToList();
            double glssLib = ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.lib ?? 0;
            double glassPerUnit = ListnewGlassType.Where(i => i.Title == glassType).SingleOrDefault()?.perUnit ?? 0;

            double squareFoot = Convert.ToDouble(squareFootInput.Split(' ')[3]);

            double glassPrise = glassPerUnit * squareFoot;
            glassPrise = Math.Round(glassPrise, 2);

            double[] data = { glssLib, glassPerUnit, glassPrise };
            return data;
        }

        public double calculateFrameType(string? frameType)
        {
            List<newFrameType> ListnewFrameType = _newAddedService.ListAllnewFrameTypes().OrderBy(i => i.Value).ToList();
            double hours = ListnewFrameType.Where(i => i.Title == frameType).SingleOrDefault()?.Value ?? 0;
            return hours;
        }

        public double[] calculateInstallers(string glassPriseInput, string glssLibInput, string squareFootInput, string hoursInput, int elevation)
        {
            int[] installersArray = { 0 };
            int id = 0;

            double squareFoot = Convert.ToDouble(squareFootInput.Split(' ')[3]);
            double glassPrise = Convert.ToDouble(glassPriseInput.Split(' ')[1]);
            double glssLib = Convert.ToDouble(glssLibInput.Split(' ')[0]);
            double hours = Convert.ToDouble(hoursInput.Split(' ')[0]);

            foreach (var lid in lidInfos)
            {
                if (elevation <= lid[1] && glssLib >= lid[2] && squareFoot >= lid[3])
                {
                    id = lid[0];
                    installersArray = installersArray.Append(lid[4]).ToArray();
                }
                else
                {
                    // If no suitable match is found
                    installersArray = installersArray.Append(-1).ToArray();
                }
            }
            int installers = installersArray.Max();
            double FinalPrice = glassPrise + (hours + installers) * 100;

            double[] data = { installers, FinalPrice };
            return data;
        }
    }
}