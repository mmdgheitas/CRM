using Infrastructure.Entity;
using Interface.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Interface.Utilities
{
    public class Controller_ActionInfo
    {
        public List<ControllerActions> FindAllController_Actions()
        {
            Assembly asm = Assembly.GetAssembly(typeof(Program));
            var controlleractionlist2 = asm.GetTypes()
                   .Where(type => typeof(Controller).IsAssignableFrom(type))
                   .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                   .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                   .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, AttributesData = x.GetCustomAttributesData(), Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                   .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();


            //Move data to class
            List<ControllerActions> CA_List = new List<ControllerActions>();
            for (int i = 0; i < controlleractionlist2.Count; i++)
            {
                try
                {
                    //find current controller
                    ControllerActions controllerItem = new ControllerActions();

                    controllerItem.cTitle = controlleractionlist2[i].Controller.Split(new[] { "Controller" }, StringSplitOptions.None)[0].ToString();
                    controllerItem.cAvailable = false;
                    controllerItem.cName = string.Empty;

                    List<Interface.Models.Action> actionListItem = new List<Interface.Models.Action>();
                    for (int j = 0; j < controlleractionlist2.Count; j++)
                    {

                        string controllerTitle = controlleractionlist2[j].Controller.Split(new[] { "Controller" }, StringSplitOptions.None)[0].ToString();
                        //find aciotns for current controller
                        if (controllerTitle == controllerItem.cTitle && IsControllerExistInList(controllerTitle, CA_List) == false)
                        {
                            Interface.Models.Action actionItem = new Interface.Models.Action();
                            actionItem.aTitle = controlleractionlist2[j].Action.ToString();
                            actionItem.ControllerTitle = controllerItem.cTitle;
                            actionItem.aAvailable = false;
                            actionItem.Name = string.Empty;
                            if (controlleractionlist2[j].Attributes.ToString() == "HttpPost")
                                actionItem.HttpPost = true;
                            else
                                actionItem.HttpPost = false;
                            if (controlleractionlist2[j].AttributesData.Where(p => p.AttributeType.Name == "CustomAuthorize").Any())
                            {
                                var Arguman = controlleractionlist2[j].AttributesData.Where(p => p.AttributeType.Name == "CustomAuthorize").FirstOrDefault();
                                actionItem.ActionCategory = Arguman.ConstructorArguments[0].Value.ToString();
                                var type = Arguman.ConstructorArguments[1].Value.ToString();
                                if (type == "0")
                                {
                                    actionItem.ActionType = ActionType.UnKnow;
                                }
                                if (type == "1")
                                {
                                    actionItem.ActionType = ActionType.Add;
                                }
                                else if (type == "2")
                                {
                                    actionItem.ActionType = ActionType.Delete;
                                }
                                else if (type == "3")
                                {
                                    actionItem.ActionType = ActionType.Read;
                                }
                                else if (type == "4")
                                {
                                    actionItem.ActionType = ActionType.System;
                                }
                                else if (type == "5")
                                {
                                    actionItem.ActionType = ActionType.Write;
                                }



                            }
                            else
                            {
                                actionItem.ActionType = ActionType.UnKnow;
                                actionItem.ActionCategory = string.Empty;
                            }
                            actionListItem.Add(actionItem);
                        }
                    }
                    if (actionListItem.Count > 0)
                    {
                        controllerItem.ActionLists = actionListItem;

                        //finally; fill Controller Actions List
                        CA_List.Add(controllerItem);
                    }
                }

                catch { continue; }
            }

            return CA_List;
        }
        public bool IsControllerExistInList(string controllerTitle, List<ControllerActions> cA_List)
        {
            foreach (var item in cA_List)
            {
                if (controllerTitle == item.cTitle)
                    return true;
            }
            return false;

        }


        public string[] GetActionInfo(string roleName)
        {
            try
            {
                switch (roleName)
                {
                    case "Default":
                        return new string[] { "Setting (System Configure)", "fa fa-cog", "0" };
                    case "EmailSetting":
                        return new string[] { "Setting(Email Service)", "fa fa-flash", "0" };
                    case "Admin":
                        return new string[] { "Users (Admin Users)", "fa fa-users", "0" };

                    //case "ReportEmail":
                    //    return new string[] { "Reports (Email Reports)", "fa fa-bar-chart", "0" };
                    case "Role":
                        return new string[] { "Users (User Roles)", "fa fa-users", "0" };
                    case "TimeLine":
                        return new string[] { "Users (User Roles)", "fa fa-users", "0" };
                    case "Customer":
                        return new string[] { "Users (Customers)", "fa fa-users", "0" };
                    default:
                        return new string[] { roleName, "fa fa-flash", "0" };
                }
            }
            catch (Exception ex)
            {
                return new string[] { roleName, "fa fa-flash", "0" };
            }
        }
    }
}