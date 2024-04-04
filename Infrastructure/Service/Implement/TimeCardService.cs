using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class TimeCardService : ITimeCardService
    {
        readonly IRepositoryBase<TimeCardEnt, long> _timecardRepo;

        public TimeCardService(IRepositoryBase<TimeCardEnt, long> timeCardRepo)
        {
            this._timecardRepo = timeCardRepo;
        }

        public bool AddTimeCard(TimeCardEnt item)
        {
            try
            {
                return _timecardRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> AddTimeCardAsync(TimeCardEnt item)
        {
            try
            {
                return await _timecardRepo.InsertAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool EditTimeCard(TimeCardEnt item)
        {
            try
            {
                return _timecardRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> EditTimeCardAsync(TimeCardEnt item)
        {
            try
            {
                return await _timecardRepo.UpdateAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public TimeCardEnt TimeCardDetails(long id)
        {
            try
            {
                return _timecardRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<TimeCardEnt> ListAllTimeCards()
        {
            try
            {
                return _timecardRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<TimeCardEnt>> ListAllTimeCardsAsync()
        {
            try
            {
                return await _timecardRepo.GetAll().ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool DeleteTimeCard(long id)
        {
            try
            {
                return _timecardRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TimeCardEnt GetCurrentTime(string userId)
        {
            try
            {
                return  _timecardRepo.GetAll().Where(p => p.UserID == userId & p.ClockOutTime == null).ToList().LastOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<TimeCardEnt> GetCurrentTimeAsync(string userId)
        {
            try
            {
                var listTimes =await _timecardRepo.GetAllAsync().Where(p => p.UserID == userId & p.ClockOutTime == null).ToListAsync();

                return  listTimes.LastOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<DateTime?> GetLastLoginTimeAsync(string userId)
        {
            try
            {
                var lastresult = await _timecardRepo.GetAllAsync().LastOrDefaultAsync(p => p.UserID == userId & p.ClockOutTime == null);//Get Last Clockin
                if (lastresult != null)
                    return lastresult.ClockInTime;
                else
                {
                    lastresult = await _timecardRepo.GetAllAsync().LastOrDefaultAsync(p => p.UserID == userId);//Get Last Clock out
                    return lastresult.ClockOutTime;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DateTime? GetLastTimeHasntLunch(string userId)
        {
            try
            {
                return _timecardRepo.GetAll().LastOrDefault(p => p.UserID == userId & p.LunchStart == null & p.LunchFinish == null)?.ClockOutTime;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
