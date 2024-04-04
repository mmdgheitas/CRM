using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IRolePermisionService
    {
        bool ExistRolePermision(string roleId, string actionCategory, string actionName);
        bool UpdateRolePermision(RolePermisionEnt rPEnt);
        bool AddRolePermision(RolePermisionEnt rPEnt);
        bool DeleteRolePermision(int iD);
        List<RolePermisionEnt> ListRolePermisionForRole(string id);
        RolePermisionEnt RolePermisionDetails(string actionName, string actionCategory, string RoleID);
        List<RolePermisionEnt> ListRolePermisionForAction(string actionCategory, ActionType actionType);
        RolePermisionEnt RolePermisionDetailsByID(int id);
        List<RolePermisionEnt> ListAllRolePermisionForAction(ActionType read);
    }
}
