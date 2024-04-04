using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entity;

namespace Infrastructure.Service.Interface
{
    public interface IReportService
    {
       Task<List<ReportEmailEnt>> ListAllReportEmailAsync(string memberId = "");
     Task<List<ReportEmailEnt>> ListReportEmailByVoiceGmailAsync(string voicegmail);
        List<ReportEmailEnt> ListEnableReportEmail(string memberID);
        bool DisableReportEmail(long id);
        bool RealyDeleteReportEmail(long id);
        ReportEmailEnt ReportEmailDetails(long id = 0);
        bool AddRepoEmail(ReportEmailEnt reportEmail);
    }
}
