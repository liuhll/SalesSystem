using System.Web.Optimization;

namespace Jeuci.SalesSystem.AdminWeb
{
    public static class BundleConfig
    {
        private const string ResourcePath = "~/Abp/Lib/{0}";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //
            //~/Bundles/vendor/basecss
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/basecss")
                .Include(string.Format(ResourcePath, "bootstrap/dist/css/bootstrap.min.css"), new CssRewriteUrlTransform())
                .Include(string.Format(ResourcePath, "metisMenu/dist/metisMenu.min.css"), new CssRewriteUrlTransform())
                .Include(string.Format(ResourcePath, "startbootstrap-sb-admin-2/dist/css/sb-admin-2.css"), new CssRewriteUrlTransform())
                .Include(string.Format(ResourcePath, "font-awesome/css/font-awesome.css"), new CssRewriteUrlTransform())
                .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                );

            //  ~/Bundles/vendor/abpcss
            bundles.Add(
              new StyleBundle("~/Bundles/vendor/abpcss")
                    .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())                                   
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())                  
              );

            //~/Bundles/vendor/basejs
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/basejs")
                .Include(
                   string.Format(ResourcePath, "jquery/dist/jquery.min.js"),
                   string.Format(ResourcePath, "bootstrap/dist/js/bootstrap.min.js"),
                   string.Format(ResourcePath, "metisMenu/dist/metisMenu.min.js"),
                   string.Format(ResourcePath, "startbootstrap-sb-admin-2/dist/js/sb-admin-2.js")
                   )
                );

            //~/Bundles/abpjs
            bundles.Add(
                new ScriptBundle("~/Bundles/abpjs")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js",

                        "~/Scripts/json2.min.js",

                        "~/Scripts/jquery-2.1.4.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js"
                        )
                );

            // ~/Bundles/pluginJs
            //bundles.Add(new ScriptBundle("~/Bundles/pluginJs")
            //    .Include(
            //        string.Format(ResourcePath, "jquery.serializeJSON/jquery.serializejson.min.js")
            //    ));

            //~/Bundles/layoutAbpjs
            bundles.Add(
                new ScriptBundle("~/Bundles/layoutAbpjs")
                    .Include(
                        "~/Scripts/json2.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/js/main.js")
                );

            #region Abandon Abp Default Bundles

            //~/Bundles/vendor/css
            //    bundles.Add(
            //        new StyleBundle("~/Bundles/vendor/css")
            //            .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
            //            .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())
            //            .Include("~/Content/toastr.min.css")
            //            .Include("~/Scripts/sweetalert/sweet-alert.css")
            //            .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
            //            .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
            //        );

            //    //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            //    bundles.Add(
            //        new ScriptBundle("~/Bundles/vendor/js/top")
            //            .Include(
            //                "~/Abp/Framework/scripts/utils/ie10fix.js",
            //                "~/Scripts/modernizr-2.8.3.js"
            //            )
            //        );

            //    //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            //    bundles.Add(
            //        new ScriptBundle("~/Bundles/vendor/js/bottom")
            //            .Include(
            //                "~/Scripts/json2.min.js",

            //                "~/Scripts/jquery-2.1.4.min.js",
            //                "~/Scripts/jquery-ui-1.11.4.min.js",

            //                "~/Scripts/bootstrap.min.js",

            //                "~/Scripts/moment-with-locales.min.js",
            //                "~/Scripts/jquery.validate.min.js",
            //                "~/Scripts/jquery.blockUI.js",
            //                "~/Scripts/toastr.min.js",
            //                "~/Scripts/sweetalert/sweet-alert.min.js",
            //                "~/Scripts/others/spinjs/spin.js",
            //                "~/Scripts/others/spinjs/jquery.spin.js",

            //                "~/Abp/Framework/scripts/abp.js",
            //                "~/Abp/Framework/scripts/libs/abp.jquery.js",
            //                "~/Abp/Framework/scripts/libs/abp.toastr.js",
            //                "~/Abp/Framework/scripts/libs/abp.blockUI.js",
            //                "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
            //                "~/Abp/Framework/scripts/libs/abp.spin.js"
            //            )
            //        );

            //    //APPLICATION RESOURCES

            //    //~/Bundles/css
            //    bundles.Add(
            //        new StyleBundle("~/Bundles/css")
            //            .Include("~/css/main.css")
            //        );

            //    //~/Bundles/js
            //    bundles.Add(
            //        new ScriptBundle("~/Bundles/js")
            //            .Include("~/js/main.js")
            //        ); 

            #endregion
        }
    }
}