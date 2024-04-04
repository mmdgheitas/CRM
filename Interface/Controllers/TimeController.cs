using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Service.Interface;

using Interface.Models;

using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Interface.Utilities;
using Interface.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Interface.Controllers
{
    [Authorize]
    public class TimeController : Controller
    {
        private readonly ITimeCardService _timeService;
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        private readonly UserManager<ApplicationUser> UserManager;
        public TimeController(ITimeCardService timeService, IMapper mapper, IRazorViewToStringRenderer razorViewToStringRenderer, UserManager<ApplicationUser> uManager, ISettingService settingService)
        {
            this._settingService = settingService;
            this._timeService = timeService;
            this._mapper = mapper;
            this.UserManager = uManager;
            this._razorViewToStringRenderer = razorViewToStringRenderer;

        }

        #region MyTimeCard
        [CustomAuthorize("TimeCard", ActionType.Read)]
        public async Task<IActionResult> MyTimeCards()
        {
            var timeCartBtn = await GetMyTimeCardAsync();
            return View(timeCartBtn);
        }

        [Authorize]
        public async Task<IActionResult> _timeCard()
        {
            var timeCartBtn = await GetMyTimeCard();
            return PartialView(timeCartBtn);
        }
        [Authorize]
        public async Task<IActionResult> _reloadTimeCard()
        {
            try
            {
                var timeCartBtn = GetMyTimeCard();

                return Json(new { success = true, Html = await _razorViewToStringRenderer.RenderViewToStringAsync("_reloadTimeCard", timeCartBtn) });


            }
            catch (Exception ex)
            {

                return Json(new { success = false });

            }
        }

        [Authorize]
        public async Task<IActionResult> _clockIn()
        {
            try
            {
                var timeCartBtn = await GetMyTimeCard();

                if (!timeCartBtn.ClockInBtn)
                    return Json(new { success = false, Html = "" });
                else
                    return Json(new { success = true, Html = await _razorViewToStringRenderer.RenderViewToStringAsync("_clockIn", timeCartBtn) });

            }
            catch (Exception ex)
            {

                return Json(new { success = false, Html = "" });

            }

        }
        //Return list of model to jqueryGRid
        //  [CustomAuthorize("TimeCard", ActionType.Read)]
        public IActionResult _myTimeCardsList(string page = "1", string rows = "10")
        {
            var userID = UserManager.GetUserId(User);
            var modelList = _mapper.Map<List<TimeCardModel>>(_timeService.ListAllTimeCards().Where(p => p.UserID == userID).OrderByDescending(p => p.ID).ToList());
            var users = UserManager.Users;


            var ListModelCount = modelList.Count;
            modelList = modelList.Skip((Int32.Parse(page) - 1) * Int32.Parse(rows)).Take(Int32.Parse(rows)).ToList();

            modelList = modelList.Select(p =>
            {
                p.ClockInTimeFa = p.ClockInTime.ToFontAwesomeDateTime();
                p.ClockOutTimeFa = p.ClockOutTime == null ? "--" : p.ClockOutTime.Value.ToFontAwesomeDateTime();

                p.LunchStartFa = p.LunchStart == null ? "--" : Convert.ToDateTime(p.LunchStart).ToString("HH:mm");
                p.LunchFinishFa = p.LunchFinish == null ? "--" : Convert.ToDateTime(p.LunchFinish).ToString("HH:mm");

                p.BreakStartFa = p.BreakStart == null ? "--" : Convert.ToDateTime(p.BreakStart).ToString("HH:mm");
                p.BreakFinishFa = p.BreakFinish == null ? "--" : Convert.ToDateTime(p.BreakFinish).ToString("HH:mm");

                if (p.ClockOutTime != null)
                {
                    p.ClockTime = ((DateTime)p.ClockOutTime - p.ClockInTime).TimeSpamToHoureMiniteShort();
                    p.ClockTime_min = ((DateTime)p.ClockOutTime - p.ClockInTime).TotalMinutes;
                }
                if (p.BreakFinish != null)
                {
                    p.BreakTime = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TimeSpamToHoureMiniteShort(_settingService.GetBreakTime());
                    p.BreakTime_min = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TotalMinutes;

                }
                if (p.LunchFinish != null)
                {
                    p.LunchTime = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TimeSpamToHoureMiniteShort();
                    p.LunchTime_min = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TotalMinutes;
                }
                p.UseBreakFa = p.BreakStart != null ? "Yes" : "--";
                return p;

            }).ToList();

            return Json(modelList.ToJqGridData(ListModelCount, page, rows));
        }

        // [CustomAuthorize("TimeCard", ActionType.Write)]
        public async Task<IActionResult> clockin()
        {
            try
            {

                var CurrentTC = _timeService.GetCurrentTime(UserManager.GetUserId(User));

                if (CurrentTC != null)
                    return Json(new { success = true, responseText = "You are already clocked in" });


                var tc = new TimeCardEnt();
                tc.UserID = UserManager.GetUserId(User);
                tc.ClockInTime = DateTime.Now.SystemTime();
                var res = await _timeService.AddTimeCardAsync(tc);
                if (!res)
                    return Json(new { success = false, responseText = "Error... Please try again." });


                return Json(new { success = true, responseText = "Clock in successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }

        }

        [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult clockout()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                tc.ClockOutTime = DateTime.Now.SystemTime();
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "Clock out successfully" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }

        // [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult clockoutForce()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                var nextDay = tc.ClockInTime.AddDays(1);
                tc.ClockOutTime = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 4, 0, 0);
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "Clock out successfully" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }

        [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult lunchstart()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                tc.LunchStart = DateTime.Now.SystemTime();
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "Lunch Started successfully" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }
        [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult lunchfinish()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                tc.LunchFinish = DateTime.Now.SystemTime();
                tc.ClockOutTime = tc.LunchStart;
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "Lunch Finished successfully" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }

        //  [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult BreakStart()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                tc.BreakStart = DateTime.Now.SystemTime();
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "You are in break" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }

        //  [CustomAuthorize("TimeCard", ActionType.Write)]
        public IActionResult BreakFinish()
        {
            try
            {
                var tc = _timeService.GetCurrentTime(UserManager.GetUserId(User));
                tc.BreakFinish = DateTime.Now.SystemTime();
                if (!_timeService.EditTimeCard(tc))
                    return Json(new { success = false, responseText = "Error... Please try again." });

                return Json(new { success = true, responseText = "You are in break" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }
        }

        [Authorize]
        public async Task<TimeCardBtn> GetMyTimeCard()
        {
            var listAllClockinNoClockout = (_timeService.ListAllTimeCards()).Where(p => p.ClockOutTime == null).ToList();
            foreach (var item in listAllClockinNoClockout)
            {
                var dayAfterClockin = item.ClockInTime.AddDays(1);
                var Time4_AM = new DateTime(dayAfterClockin.Year, dayAfterClockin.Month, dayAfterClockin.Day, 4, 0, 0);

                if (item.ClockInTime < Time4_AM && DateTime.Now.SystemTime() >= Time4_AM)
                {
                    item.ClockOutTime = Time4_AM;
                    var result = _timeService.EditTimeCard(item);
                }
            }

            var currentTime = _timeService.GetCurrentTime(UserManager.GetUserId(User));
            var timeCartBtn = new TimeCardBtn();
            timeCartBtn.Now = DateTime.Now.SystemTime();
            timeCartBtn.BreakTime = _settingService.GetBreakTime();

            if (currentTime == null)
            {
                timeCartBtn.ClockInBtn = true;
                timeCartBtn.StartTime = DateTime.Now.SystemTime();
            }
            else
            {
                timeCartBtn.StartTime = currentTime.ClockInTime;
                if ((DateTime.Now.SystemTime() - currentTime.ClockInTime).TotalMinutes < 120) // if checkin time more than 2 hourse
                {
                    timeCartBtn.ClockOutBtn = true;
                    timeCartBtn.ClockInBtn = false;
                }
                else
                {
                    timeCartBtn.ClockOutBtn = true;

                    if (currentTime.BreakStart == null & currentTime.BreakFinish == null)//befor Break
                    {
                        timeCartBtn.BreakStartBtn = true;
                        timeCartBtn.BreakFinishBtn = false;
                    }
                    if (currentTime.BreakStart != null & currentTime.BreakFinish == null)//in Break
                    {
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.BreakFinishBtn = true;
                        timeCartBtn.ClockOutBtn = false;
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.LunchStartBtn = false;
                        timeCartBtn.StartTime = Convert.ToDateTime(currentTime.BreakStart);
                        timeCartBtn.inBreak = true;
                    }
                    if (currentTime.BreakStart != null & currentTime.BreakFinish != null)//after Break
                    {
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.BreakFinishBtn = false;
                    }
                    if (!timeCartBtn.inBreak)
                    {
                        if (currentTime.LunchStart == null & currentTime.LunchFinish == null)//befor lunch
                        {
                            timeCartBtn.LunchStartBtn = true;
                            timeCartBtn.LunchFinishBtn = false;
                        }
                        if (currentTime.LunchStart != null & currentTime.LunchFinish == null)//in lunch
                        {
                            timeCartBtn.LunchStartBtn = false;
                            timeCartBtn.LunchFinishBtn = true;
                            timeCartBtn.ClockOutBtn = false;
                            timeCartBtn.BreakStartBtn = false;
                            timeCartBtn.StartTime = Convert.ToDateTime(currentTime.LunchStart);
                            timeCartBtn.inLunch = true;
                        }
                        if (currentTime.LunchStart != null & currentTime.LunchFinish != null)//after lunch
                        {
                            timeCartBtn.LunchStartBtn = false;
                            timeCartBtn.LunchFinishBtn = false;
                        }
                    }
                    if (!timeCartBtn.inBreak & !timeCartBtn.inLunch & false)//فعلا غیر فعال باشد
                    {

                        if ((DateTime.Now.SystemTime() - currentTime.ClockInTime).TotalMinutes >= 300 & currentTime.LunchStart == null & currentTime.LunchFinish == null)//check if time more than 5 hourse
                        {
                            var BreakFinish = currentTime.BreakFinish ?? DateTime.Now.SystemTime().AddMinutes(-5);
                            if ((DateTime.Now.SystemTime() - BreakFinish).TotalMinutes >= 2)//اگر بریک خود را آخر ۵ ساعت گرفت ۲ دقیقه مهلت دارد لانچ بگیرد
                            {
                                currentTime.ClockOutTime = currentTime.ClockInTime.AddHours(5);
                                _timeService.EditTimeCard(currentTime);

                                //  return RedirectToAction("LogOff", "Account");
                            }
                        }
                    }

                }

            }


            return timeCartBtn;
        }

        [Authorize]
        public async Task<TimeCardBtn> GetMyTimeCardAsync()
        {
            var listAllClockinNoClockout = (await _timeService.ListAllTimeCardsAsync()).Where(p => p.ClockOutTime == null).ToList();
            foreach (var item in listAllClockinNoClockout)
            {
                var dayAfterClockin = item.ClockInTime.AddDays(1);
                var Time4_AM = new DateTime(dayAfterClockin.Year, dayAfterClockin.Month, dayAfterClockin.Day, 4, 0, 0);

                if (item.ClockInTime < Time4_AM && DateTime.Now.SystemTime() >= Time4_AM)
                {
                    item.ClockOutTime = Time4_AM;
                    var result = await _timeService.EditTimeCardAsync(item);
                }
            }

            var currentTime = await _timeService.GetCurrentTimeAsync(UserManager.GetUserId(User));
            var timeCartBtn = new TimeCardBtn();
            timeCartBtn.Now = DateTime.Now.SystemTime();
            timeCartBtn.BreakTime = await _settingService.GetBreakTimeASync();

            if (currentTime == null)
            {
                timeCartBtn.ClockInBtn = true;
                timeCartBtn.StartTime = DateTime.Now.SystemTime();
            }
            else
            {
                timeCartBtn.StartTime = currentTime.ClockInTime;
                if ((DateTime.Now.SystemTime() - currentTime.ClockInTime).TotalMinutes < 120) // if checkin time more than 2 hourse
                {
                    timeCartBtn.ClockOutBtn = true;
                    timeCartBtn.ClockInBtn = false;
                }
                else
                {
                    timeCartBtn.ClockOutBtn = true;

                    if (currentTime.BreakStart == null & currentTime.BreakFinish == null)//befor Break
                    {
                        timeCartBtn.BreakStartBtn = true;
                        timeCartBtn.BreakFinishBtn = false;
                    }
                    if (currentTime.BreakStart != null & currentTime.BreakFinish == null)//in Break
                    {
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.BreakFinishBtn = true;
                        timeCartBtn.ClockOutBtn = false;
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.LunchStartBtn = false;
                        timeCartBtn.StartTime = Convert.ToDateTime(currentTime.BreakStart);
                        timeCartBtn.inBreak = true;
                    }
                    if (currentTime.BreakStart != null & currentTime.BreakFinish != null)//after Break
                    {
                        timeCartBtn.BreakStartBtn = false;
                        timeCartBtn.BreakFinishBtn = false;
                    }
                    if (!timeCartBtn.inBreak)
                    {
                        if (currentTime.LunchStart == null & currentTime.LunchFinish == null)//befor lunch
                        {
                            timeCartBtn.LunchStartBtn = true;
                            timeCartBtn.LunchFinishBtn = false;
                        }
                        if (currentTime.LunchStart != null & currentTime.LunchFinish == null)//in lunch
                        {
                            timeCartBtn.LunchStartBtn = false;
                            timeCartBtn.LunchFinishBtn = true;
                            timeCartBtn.ClockOutBtn = false;
                            timeCartBtn.BreakStartBtn = false;
                            timeCartBtn.StartTime = Convert.ToDateTime(currentTime.LunchStart);
                            timeCartBtn.inLunch = true;
                        }
                        if (currentTime.LunchStart != null & currentTime.LunchFinish != null)//after lunch
                        {
                            timeCartBtn.LunchStartBtn = false;
                            timeCartBtn.LunchFinishBtn = false;
                        }
                    }
                    if (!timeCartBtn.inBreak & !timeCartBtn.inLunch & false)//فعلا غیر فعال باشد
                    {

                        if ((DateTime.Now.SystemTime() - currentTime.ClockInTime).TotalMinutes >= 300 & currentTime.LunchStart == null & currentTime.LunchFinish == null)//check if time more than 5 hourse
                        {
                            var BreakFinish = currentTime.BreakFinish ?? DateTime.Now.SystemTime().AddMinutes(-5);
                            if ((DateTime.Now.SystemTime() - BreakFinish).TotalMinutes >= 2)//اگر بریک خود را آخر ۵ ساعت گرفت ۲ دقیقه مهلت دارد لانچ بگیرد
                            {
                                currentTime.ClockOutTime = currentTime.ClockInTime.AddHours(5);
                                _timeService.EditTimeCard(currentTime);

                                //  return RedirectToAction("LogOff", "Account");
                            }
                        }
                    }

                }

            }


            return timeCartBtn;
        }
        #endregion

        #region List Time Cards

        [CustomAuthorize("ListTimeCard", ActionType.Read)]
        public async Task<IActionResult> ListTimeCards(string id = "")
        {
            var search = new TimeCardSearch();
            search.UserID = id;
            search.StartDate = DateTime.Now.SystemTime().AddDays(-14).ToString("d");
            search.EndDate = DateTime.Now.SystemTime().ToString("d");
            var listUser = _mapper.Map<List<appUser>>((await UserManager.GetUsersInRoleAsync("Admin")).Where(p => p.UserType != UserType.User & p.isActive).ToList());

            listUser = listUser.Select(p => { p.FullName = (p?.FirstName ?? "") + " " + (p?.LastName ?? ""); return p; }).ToList();
            listUser.Add(new appUser() { FullName = "All User", Id = "" });
            search.ListUser = listUser.OrderByDescending(p => p.Id == "").ToList();
            return View(search);
        }

        [CustomAuthorize("ListTimeCard", ActionType.Read)]
        public IActionResult _listTimeCards(string id = "", string page = "1", string rows = "10")
        {

            var modelList = _mapper.Map<List<TimeCardModel>>(_timeService.ListAllTimeCards().Where(p => (string.IsNullOrEmpty(id) == false ? p.UserID == id : true)).OrderByDescending(p => p.ID).ToList());
            var users = UserManager.Users;

            try
            {
                DateTime StartDate = DateTime.Now.SystemTime().AddDays(-14);
                DateTime EndDate = DateTime.Now.SystemTime();


                modelList = modelList.Where(p =>
                (p.ClockInTime != null ? p.ClockInTime >= new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0) : true) &
               (p.ClockInTime != null ? p.ClockInTime <= new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59) : true)
              ).ToList();

            }
            catch { }



            modelList = modelList.Select(p =>
            {
                p.ClockInTimeFa = p.ClockInTime.ToFontAwesomeDateTime();
                p.ClockOutTimeFa = p.ClockOutTime == null ? "--" : p.ClockOutTime.Value.ToFontAwesomeDateTime();

                p.LunchStartFa = p.LunchStart == null ? "--" : Convert.ToDateTime(p.LunchStart).ToString("HH:mm");
                p.LunchFinishFa = p.LunchFinish == null ? "--" : Convert.ToDateTime(p.LunchFinish).ToString("HH:mm");

                p.BreakStartFa = p.BreakStart == null ? "--" : Convert.ToDateTime(p.BreakStart).ToString("HH:mm");
                p.BreakFinishFa = p.BreakFinish == null ? "--" : Convert.ToDateTime(p.BreakFinish).ToString("HH:mm");

                var appUser = users.FirstOrDefault(u => u.Id == p.UserID);

                if (appUser != null)
                    p.FullName = (appUser?.FirstName ?? "") + " " + (appUser?.LastName ?? "");


                if (p.ClockOutTime != null)
                {
                    p.ClockTime = ((DateTime)p.ClockOutTime - p.ClockInTime).TimeSpamToHoureMiniteShort();
                    p.ClockTime_min = ((DateTime)p.ClockOutTime - p.ClockInTime).TotalMinutes;
                }
                if (p.BreakFinish != null)
                {
                    p.BreakTime = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TimeSpamToHoureMiniteShort(_settingService.GetBreakTime());
                    p.BreakTime_min = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TotalMinutes;

                }
                if (p.LunchFinish != null)
                {
                    p.LunchTime = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TimeSpamToHoureMiniteShort();
                    p.LunchTime_min = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TotalMinutes;
                }
                p.UseBreakFa = p.BreakStart != null ? "Yes" : "--";

                if (p.ClockOutTime != null)
                    p.Status = "Finish";
                else
                {
                    if (p.LunchStart != null & p.LunchFinish == null)
                        p.Status = "At lunch";
                    else if (p.BreakStart != null & p.BreakFinish == null)
                        p.Status = "At Break";
                    else if (p.ClockInTime != null & p.ClockOutTime == null)
                        p.Status = "At work";
                }

                return p;

            }).ToList();

            var ListModelCount = modelList.Count;
            modelList = modelList.Skip((Int32.Parse(page) - 1) * Int32.Parse(rows)).Take(Int32.Parse(rows)).ToList();

            return Json(modelList.ToJqGridData(ListModelCount, page, rows));
        }



        [CustomAuthorize("ListTimeCard", ActionType.Read)]
        public IActionResult _listSearchTimeCards(TimeCardSearch search, string page = "1", string rows = "10")
        {
            var modelList = _mapper.Map<List<TimeCardModel>>(_timeService.ListAllTimeCards().Where(p => (string.IsNullOrEmpty(search.UserID) == false ? p.UserID == search.UserID : true)).OrderByDescending(p => p.ID).ToList());
            var users = UserManager.Users;
            try
            {
                DateTime StartDate = (string.IsNullOrWhiteSpace(search.StartDate)) ? DateTime.Now.SystemTime().AddYears(-100) : DateTime.Parse(search.StartDate);
                DateTime EndDate = (string.IsNullOrWhiteSpace(search.EndDate)) ? DateTime.Now.SystemTime().AddYears(100) : DateTime.Parse(search.EndDate);

                modelList = modelList.Where(p =>
                (p.ClockInTime != null ? p.ClockInTime >= new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0) : true) &
               (p.ClockInTime != null ? p.ClockInTime <= new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59) : true)
              ).ToList();

            }
            catch { }

            modelList = modelList.Select(p =>
            {
                p.ClockInTimeFa = p.ClockInTime.ToFontAwesomeDateTime();
                p.ClockOutTimeFa = p.ClockOutTime == null ? "--" : p.ClockOutTime.Value.ToFontAwesomeDateTime();

                p.LunchStartFa = p.LunchStart == null ? "--" : Convert.ToDateTime(p.LunchStart).ToString("HH:mm");
                p.LunchFinishFa = p.LunchFinish == null ? "--" : Convert.ToDateTime(p.LunchFinish).ToString("HH:mm");

                p.BreakStartFa = p.BreakStart == null ? "--" : Convert.ToDateTime(p.BreakStart).ToString("HH:mm");
                p.BreakFinishFa = p.BreakFinish == null ? "--" : Convert.ToDateTime(p.BreakFinish).ToString("HH:mm");

                var appUser = users.FirstOrDefault(u => u.Id == p.UserID);

                if (appUser != null)
                    p.FullName = (appUser?.FirstName ?? "") + " " + (appUser?.LastName ?? "");

                if (p.ClockOutTime != null)
                {
                    p.ClockTime = ((DateTime)p.ClockOutTime - p.ClockInTime).TimeSpamToHoureMiniteShort();
                    p.ClockTime_min = ((DateTime)p.ClockOutTime - p.ClockInTime).TotalMinutes;
                }
                if (p.BreakFinish != null)
                {
                    p.BreakTime = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TimeSpamToHoureMiniteShort(_settingService.GetBreakTime());
                    p.BreakTime_min = ((DateTime)p.BreakFinish - (DateTime)p.BreakStart).TotalMinutes;

                }
                if (p.LunchFinish != null)
                {
                    p.LunchTime = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TimeSpamToHoureMiniteShort();
                    p.LunchTime_min = ((DateTime)p.LunchFinish - (DateTime)p.LunchStart).TotalMinutes;
                }

                p.UseBreakFa = p.BreakStart != null ? "Yes" : "--";

                if (p.ClockOutTime != null)
                    p.Status = "Finish";
                else
                {
                    if (p.LunchStart != null & p.LunchFinish == null)
                        p.Status = "At lunch";
                    else if (p.BreakStart != null & p.BreakFinish == null)
                        p.Status = "At Break";
                    else if (p.ClockInTime != null & p.ClockOutTime == null)
                        p.Status = "At work";
                }
                return p;

            }).ToList();

            if (modelList.Count > 0)
                if (modelList.Count(p => p.UserID == modelList.FirstOrDefault().UserID) == modelList.Count())
                    modelList.Add(new TimeCardModel()
                    {
                        ID = 0,
                        FullName = "Total",
                        ClockInTimeFa = "--",
                        ClockOutTimeFa = "--",
                        ClockTime = modelList.Sum(p => p.ClockTime_min).MiniteToHoure(),
                        LunchTime = modelList.Sum(p => p.LunchTime_min).MiniteToHoure(),
                        BreakTime = modelList.Sum(p => p.BreakTime_min).MiniteToHoure(),
                        Status = "--",
                        BreakStartFa = "--",
                        LunchStartFa = "--",
                    });

            var ListModelCount = modelList.Count;
            modelList = modelList.Skip((Int32.Parse(page) - 1) * Int32.Parse(rows)).Take(Int32.Parse(rows)).ToList();

            return Json(modelList.ToJqGridData(ListModelCount, page, rows));
        }

        // [CustomAuthorize("ListTimeCard", ActionType.Delete)]
        public IActionResult deleteTimeCard(long id)
        {
            try
            {
                if (_timeService.DeleteTimeCard(id))
                {
                    return Json(new { success = true, responseText = "Record deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Error... Please try again." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Error... Please try again." });
            }

        }

        ///    [CustomAuthorize("ListTimeCard", ActionType.Write)]
        public IActionResult _editTimeCard(long id = 0)
        {
            try
            {

                var time = _mapper.Map<TimeCardModel>(_timeService.TimeCardDetails(id));
                if (id == 0)
                {
                    var Now = DateTime.Now.SystemTime();
                    time = new TimeCardModel() { ClockInTime = Now, ClockOutTime = Now };

                    var Users = _mapper.Map<List<User>>(UserManager.Users.Where(p => p.isActive == true).Where(p => p.UserType == UserType.Installer | p.UserType == UserType.Estimator | p.UserType == UserType.Installer_Estimator || p.UserType == UserType.Admin).OrderBy(p => p.UserType == UserType.Admin).ToList());
                    ViewBag.ListUser = Users.Select(p => { p.FirstName = p.FirstName + " " + p.LastName; return p; }).ToList();
                }
                time.ClockInTimeFa = time.ClockInTime.ToString("yyyy/MM/dd");
                time.ClockInTimeStr = time.ClockInTime.ToString("HH:mm");
                if (time.ClockOutTime != null)
                {
                    time.ClockOutTimeFa = Convert.ToDateTime(time.ClockOutTime).ToString("yyyy/MM/dd");
                    time.ClockOutTimeStr = Convert.ToDateTime(time.ClockOutTime).ToString("HH:mm");
                }

                if (time.BreakStart != null)
                {
                    time.BreakStartFa = Convert.ToDateTime(time.BreakStart).ToString("yyyy/MM/dd");
                    time.BreakStartTime = Convert.ToDateTime(time.BreakStart).ToString("HH:mm");
                }
                if (time.BreakFinish != null)
                {
                    time.BreakFinishFa = Convert.ToDateTime(time.BreakFinish).ToString("yyyy/MM/dd");
                    time.BreakFinishTime = Convert.ToDateTime(time.BreakFinish).ToString("HH:mm");
                }

                if (time.LunchStart != null)
                {
                    time.LunchStartFa = Convert.ToDateTime(time.LunchStart).ToString("yyyy/MM/dd");
                    time.LunchStartTime = Convert.ToDateTime(time.LunchStart).ToString("HH:mm");
                }
                if (time.LunchFinish != null)
                {
                    time.LunchFinishFa = Convert.ToDateTime(time.LunchFinish).ToString("yyyy/MM/dd");
                    time.LunchFinishTime = Convert.ToDateTime(time.LunchFinish).ToString("HH:mm");
                }

                return PartialView(time);
            }
            catch (Exception ex)
            {
                return PartialView(new TimeCardModel());
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // [CustomAuthorize("ListTimeCard", ActionType.Write)]
        public IActionResult _editTimeCard(TimeCardModel item)
        {
            try
            {
                try
                {
                    var date = DateTime.Now.SystemTime();
                    if (!string.IsNullOrWhiteSpace(item.ClockInTimeFa))
                    {
                        date = DateTime.Parse(item.ClockInTimeFa);
                        item.ClockInTime = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.ClockInTimeStr.Split(':')[0]), Int32.Parse(item.ClockInTimeStr.Split(':')[1]), 0);
                    }
                    if (!string.IsNullOrWhiteSpace(item.ClockOutTimeFa))
                    {
                        date = DateTime.Parse(item.ClockOutTimeFa);
                        item.ClockOutTime = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.ClockOutTimeStr.Split(':')[0]), Int32.Parse(item.ClockOutTimeStr.Split(':')[1]), 0);
                    }
                    if (!string.IsNullOrWhiteSpace(item.LunchStartFa))
                    {
                        date = DateTime.Parse(item.LunchStartFa);
                        item.LunchStart = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.LunchStartTime.Split(':')[0]), Int32.Parse(item.LunchStartTime.Split(':')[1]), 0);
                    }
                    if (!string.IsNullOrWhiteSpace(item.LunchFinishFa))
                    {
                        date = DateTime.Parse(item.LunchFinishFa);
                        item.LunchFinish = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.LunchFinishTime.Split(':')[0]), Int32.Parse(item.LunchFinishTime.Split(':')[1]), 0);
                    }
                    if (!string.IsNullOrWhiteSpace(item.BreakStartFa))
                    {
                        date = DateTime.Parse(item.BreakStartFa);
                        item.BreakStart = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.BreakStartTime.Split(':')[0]), Int32.Parse(item.BreakStartTime.Split(':')[1]), 0);
                    }
                    if (!string.IsNullOrWhiteSpace(item.BreakFinishFa))
                    {
                        date = DateTime.Parse(item.BreakFinishFa);
                        item.BreakFinish = new DateTime(date.Year, date.Month, date.Day, Int32.Parse(item.BreakFinishTime.Split(':')[0]), Int32.Parse(item.BreakFinishTime.Split(':')[1]), 0);
                    }

                    if (item.ClockInTime > item.ClockOutTime)
                        return Json(new { success = false, responseText = "The clock in time must be before the clock out time" });

                    if (item.BreakStart > item.BreakFinish)
                        return Json(new { success = false, responseText = "The break start time must be before the break finish time" });

                    if (item.LunchStart > item.LunchFinish)
                        return Json(new { success = false, responseText = "The luch start time must be before the lunch finish time" });

                    if (item.BreakStart < item.ClockInTime | item.BreakFinish > item.ClockOutTime)
                        return Json(new { success = false, responseText = "The break should be between working times" });

                }
                catch (Exception)
                {
                    return Json(new { success = false, responseText = "Error... Please check your input." });

                }

                var model = _mapper.Map<TimeCardEnt>(item);
                if (item.ID == 0)
                {
                    if (!_timeService.AddTimeCard(model))
                    {
                        return Json(new { success = false, responseText = "Error... Please try again." });
                    }

                }
                else
                {
                    if (!_timeService.EditTimeCard(model))
                    {
                        return Json(new { success = false, responseText = "Error... Please try again." });
                    }
                }
                return Json(new { success = true, responseText = "Data saved successfully." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = GetErrorListFromModelState(ModelState, ex.Message) });

            }
        }

        #endregion

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

    }

}