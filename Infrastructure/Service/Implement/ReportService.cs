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
    public class ReportService : IReportService
    {
        IRepositoryBase<ReportEmailEnt, long> _reportEmailRepo;

        public ReportService(IRepositoryBase<ReportEmailEnt, long> _reportEmailRepo)
        {
            this._reportEmailRepo = _reportEmailRepo;
        }

        public bool AddRepoEmail(ReportEmailEnt reportEmail)
        {
            try
            {
                return _reportEmailRepo.Insert2(reportEmail);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DisableReportEmail(long id)
        {
            try
            {
                var Report = _reportEmailRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
                Report.Delete = true;

                return _reportEmailRepo.Update2(Report);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<ReportEmailEnt>> ListAllReportEmailAsync(string memberId = "")
        {
            try
            {
                if (memberId == null) return new List<ReportEmailEnt>();
                if (memberId == "")
                    return await _reportEmailRepo.GetAllAsync().ToListAsync();
                else
                    return await _reportEmailRepo.GetAllAsync().Where(p => p.MemberID == memberId).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ReportEmailEnt>> ListReportEmailByVoiceGmailAsync(string voiceGmail)
        {
            try
            {
                if (voiceGmail == null) return new List<ReportEmailEnt>();
                return await _reportEmailRepo.GetAllAsync().Where(p => p.ReciverEmail == voiceGmail).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ReportEmailEnt> ListEnableReportEmail(string memberId)
        {
            try
            {
                if (memberId == null) return new List<ReportEmailEnt>();
                return _reportEmailRepo.GetAll().Where(p => p.Delete == false & p.MemberID == memberId).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool RealyDeleteReportEmail(long id)
        {
            try
            {
                return _reportEmailRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public ReportEmailEnt ReportEmailDetails(long id = 0)
        {
            try
            {
                return _reportEmailRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
