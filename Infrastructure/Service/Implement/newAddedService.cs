using Infrastructure.Entity;
using Infrastructure.Entity.newAdded;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class newAddedService : InewAddedService
    {
        private IRepositoryBase<newGlassType, int> _newGlassTypeRepo;
        private IRepositoryBase<newFrameType, int> _newFrameTypeRepo;

        public newAddedService(IRepositoryBase<newGlassType, int> _newGlassTypeRepo, IRepositoryBase<newFrameType, int> _newFrameTypeRepo)
        {
            this._newGlassTypeRepo = _newGlassTypeRepo;
            this._newFrameTypeRepo = _newFrameTypeRepo;
        }

        public List<newGlassType> ListAllnewGlassTypes()
        {
            try
            {
                return _newGlassTypeRepo.GetAll().OrderBy(p => p.Priority).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<newFrameType> ListAllnewFrameTypes()
        {
            try
            {
                return _newFrameTypeRepo.GetAll().OrderBy(p => p.Value).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}