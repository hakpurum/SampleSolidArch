using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sample.Mvc.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQueryUI CSS
            bundles.Add(new StyleBundle("~/bundles/jqueryuiStyles").Include("~/Content/themes/base/*.css"));
            //Bootstrap Css
            bundles.Add(new StyleBundle("~/bundles/bootstrapStyles").Include("~/Content/bootstrap.min.css", "~/Content/bootstrap-theme.min.css"));




            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.2.3.js"));
            //jQuery validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*","~/Scripts/jquery.validate*"));
            // jQueryUI 
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-1.11.4.min.js"));
            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
        }
    }
}