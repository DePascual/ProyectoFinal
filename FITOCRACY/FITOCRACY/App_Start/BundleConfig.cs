using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FITOCRACY.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Librerias descargadas
            bundles.Add(
                new ScriptBundle("~/bundles/libraries")
                    .Include("~/Scripts/Angular/angular.js")
                    .Include("~/Scripts/Angular/angular-route.js")
                    .Include("~/Scripts/Angular/angular-resource.js")
                    .Include("~/Scripts/bootstrap.js")
                    .Include("~/Scripts/jquery-1.9.1.js")
                );

            //Archivos CSS de la app
            bundles.Add(
                new StyleBundle("~/bundles/css")
                    .Include("~/Content/bootstrap.css")
                    .Include("~/Content/bootstrap-theme.css")
                    .Include("~/css/font-awesome.css")
                    .Include("~/css/Fitocracy.css")
                );

            //Archivos javascript de la app
            bundles.Add(
                new ScriptBundle("~/bundles/Fitocracy")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .Include("~/Scripts/Fitocracy/Fitocracy.js")
               );

        }
    }
}