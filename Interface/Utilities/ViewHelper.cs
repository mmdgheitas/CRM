using Interface.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


public static class ViewHelper
{
    //public class EmptyController : ControllerBase { protected override void ExecuteCore() { throw new NotImplementedException(); } };
    
    public static string ShowAlert(this IHtmlHelper helper, string Message, string Type = "danger")
    {



        string retuenPM = "<div class=\"alert alert-" + Type + " margin-bottom-30\" style=\"text-align:left; display:normal;\">";
        retuenPM += "<button type =\"button\" class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">×</span><span class=\"sr-only\">Close</span></button>";

        retuenPM += Message;
        retuenPM += "</div>";


        return retuenPM;
    }

    public static string ShowAlertWithimage(this IHtmlHelper helper, string Message, string Type = "danger")
    {
        string retuenPM = "<div class=\"alert alert-" + Type + " margin-bottom-30\" style=\"text-align:left; display:normal;\">";
        retuenPM += "<button type =\"button\" class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">×</span><span class=\"sr-only\">Close</span></button>";
        if (Type == "danger")
            retuenPM += "<img src=\"../Content/themes/AccountingAdmin/assets/plugins/TakLibLogin/img/error.png\" />";
        else
            retuenPM += "<img  src=\"../Content/themes/AccountingAdmin/assets/plugins/TakLibLogin/img/success.png\" />";
        retuenPM += "  ";
        retuenPM += Message;
        retuenPM += "</div>";


        return retuenPM;
    }

  


}