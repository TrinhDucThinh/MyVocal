using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyVocal.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "Login",
               url: "tai-khoan/dang-nhap",
               defaults: new { controller = "Account", action = "Login" },
                 namespaces: new string[] { "MyVocal.Web.Controllers" }
           );

            routes.MapRoute(
               name: "Register",
               url: "tai-khoan/dang-ky",
               defaults: new { controller = "Account", action = "Register" },
                 namespaces: new string[] { "MyVocal.Web.Controllers" }
           );

            routes.MapRoute(
               name: "LearnTopic",
               url: "chu-de/hoc-chu-de/{id}",
               defaults: new { controller = "Topic", action = "LearnTopic", id=UrlParameter.Optional},
                 namespaces: new string[] { "MyVocal.Web.Controllers" }
           );

            routes.MapRoute(
               name: "TestTopic",
               url: "chu-de/kiem-tra-chu-de/{id}",
               defaults: new { controller = "Topic", action = "TestTopic", id = UrlParameter.Optional },
                 namespaces: new string[] { "MyVocal.Web.Controllers" }
           );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new string[] { "MyVocal.Web.Controllers" }
            );
        }
    }
}
