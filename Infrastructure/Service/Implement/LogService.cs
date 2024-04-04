using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Service.Implement
{
    public class LogService : ILogService
    {
        IRepositoryBase<LogEnt, long> _LogRepo;
        IRepositoryBase<MsgNotificationEnt, long> _msgNotificationRepo;
        public LogService(IRepositoryBase<LogEnt, long> loglRepo, IRepositoryBase<MsgNotificationEnt, long> msgNotificationRepo)
        {
            this._LogRepo = loglRepo;
            this._msgNotificationRepo = msgNotificationRepo;
        }
        public LogService(IRepositoryBase<LogEnt, long> loglRepo)
        {
            this._LogRepo = loglRepo;
        }

        public async Task<bool> AddLog(LogEnt log)
        {
            try
            {
            
                return _LogRepo.Insert2(log);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool deleteLog(long id)
        {
            try
            {
                return _LogRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<LogEnt> ListAllLog(string UserID = null)
        {
            try
            {
                if (UserID == null)
                    return _LogRepo.GetAll().ToList();
                else
                    return _LogRepo.GetAll().Where(p => p.UserID == UserID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public LogEnt LogDetails(long id = 0)
        {
            try
            {
                return _LogRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddMsgNotificationForAdmin(string title, string description, DateTime date)
        {
            try
            {
                var msg = new MsgNotificationEnt();
                msg.Date = date;
                msg.Title = title;
                msg.Description = description;
                msg.forAdmin = true;
                msg.forAll = false;
                msg.ReadIDs = "";
                msg.AlertIDs = "";
                return _msgNotificationRepo.Insert(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddMsgNotificationForUser(string title, string description, string userId, DateTime date)
        {
            try
            {
                var msg = new MsgNotificationEnt();
                msg.Date = date;
                msg.Title = title;
                msg.UserID = userId;
                msg.Description = description;
                msg.forAdmin = false;
                msg.forAll = false;
                msg.ReadIDs = "";
                msg.AlertIDs = "";
                return _msgNotificationRepo.Insert(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<MsgNotificationEnt> ListAllMsg()
        {
            try
            {
                return _msgNotificationRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> EditMessage(MsgNotificationEnt msg)
        {
            try
            {
                return await _msgNotificationRepo.UpdateAsync(msg);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
