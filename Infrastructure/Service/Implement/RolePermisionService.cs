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
    public class RolePermisionService : IRolePermisionService
    {
        IRepositoryBase<RolePermisionEnt, int> _rolePermision;
        public RolePermisionService(IRepositoryBase<RolePermisionEnt, int> _rolePermision)
        {
            this._rolePermision = _rolePermision;
        }

        public bool AddRolePermision(RolePermisionEnt rPEnt)
        {
            try
            {
                return _rolePermision.Insert(rPEnt);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRolePermision(int iD)
        {
            try
            {
                return _rolePermision.Delete(iD);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ExistRolePermision(string roleId, string actionCategory, string actionName)
        {
            try
            {
                return _rolePermision.GetAll().Where(p => p.RoleID == roleId & p.ActionCategory == actionCategory & p.ActionName == actionName).Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RolePermisionEnt> ListRolePermisionForAction(string actionCategory, ActionType actionType)
        {
            try
            {
                if (actionType == ActionType.Read)
                    return _rolePermision.GetAll().Where(p => p.ActionCategory == actionCategory & p.Read == true).ToList();
                else if (actionType == ActionType.Write)
                    return _rolePermision.GetAll().Where(p => p.ActionCategory == actionCategory & p.Write == true).ToList();
                else if (actionType == ActionType.Delete)
                    return _rolePermision.GetAll().Where(p => p.ActionCategory == actionCategory & p.Delete == true).ToList();
                else
                    return _rolePermision.GetAll().Where(p => p.ActionCategory == actionCategory).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RolePermisionEnt> ListRolePermisionForRole(string id)
        {
            try
            {
                return _rolePermision.GetAll().Where(p => p.RoleID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RolePermisionEnt RolePermisionDetails(string actionName, string actionCategory, string RoleId)
        {
            try
            {
                return _rolePermision.GetAll().Where(p => p.ActionName == actionName & p.ActionCategory == actionCategory & p.RoleID == RoleId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RolePermisionEnt RolePermisionDetailsByID(int id)
        {
            try
            {
                return _rolePermision.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool UpdateRolePermision(RolePermisionEnt rPEnt)
        {
            try
            {
                return _rolePermision.Update(rPEnt);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RolePermisionEnt> ListAllRolePermisionForAction(ActionType actionType)
        {
            try
            {
                if (actionType == ActionType.Read)
                    return _rolePermision.GetAll().Where(p => p.Read == true).ToList();
                else if (actionType == ActionType.Write)
                    return _rolePermision.GetAll().Where(p => p.Write == true).ToList();
                else if (actionType == ActionType.Delete)
                    return _rolePermision.GetAll().Where(p => p.Delete == true).ToList();
                else
                    return _rolePermision.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      
    }
}
