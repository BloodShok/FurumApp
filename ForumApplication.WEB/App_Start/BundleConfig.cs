using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace ForumApplication.WEB.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scrits/app")
               .Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/bootstrap.js"
                        ));


            bundles.Add(new StyleBundle("~/bundles/css/app")
                .Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/bootstrap.css",
                "~/Content/MainPageStyle.css"
                ));
        }
    }
}