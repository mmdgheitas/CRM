using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entity;

namespace Infrastructure.Service.Interface
{
    public interface ILogService
    {
        List<LogEnt> ListAllLog(string memberId = null);
        IQueryable<MsgNotificationEnt> ListAllMsg();
        LogEnt LogDetails(long id = 0);
 
        Task<bool> AddLog(LogEnt log);
        bool deleteLog(long id);
        bool AddMsgNotificationForAdmin(string title, string description,DateTime date);
        bool AddMsgNotificationForUser(string title, string description, string userId,DateTime date);
        Task<bool> EditMessage(MsgNotificationEnt msg);
    }
}
