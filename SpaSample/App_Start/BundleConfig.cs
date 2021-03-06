﻿using System.Web;
using System.Web.Optimization;

namespace SpaSample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                    "~/Scripts/knockout-{version}.js",
                    "~/Scripts/knockout.validation.js",
                    "~/Scripts/knockout.mapping-latest.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/director").Include(
                        "~/Scripts/director.js"));

            bundles.Add(new ScriptBundle("~/bundles/require").Include(
                        "~/Scripts/require.js",
                        "~/Scripts/require.text.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/site.css"));

            // scripts for the application
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/site/app.js",
                    "~/Scripts/site/viewmodel.js"
                    ));
        }
    }
}
