using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class HelpService : IHelpService
    {
        IRepositoryBase<HelpEnt, int> _helpRepo;



        public HelpService(IRepositoryBase<HelpEnt, int> _helpRepo)
        {
            this._helpRepo = _helpRepo;
        }

        public List<HelpEnt> ListAllHelps()
        {
            try
            {
                return _helpRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
