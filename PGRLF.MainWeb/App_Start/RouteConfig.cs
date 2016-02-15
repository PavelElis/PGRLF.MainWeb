using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PGRLF.MainWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "FormShow",
                url: "Form/{techname}",
                defaults: new { controller = "Form", action = "Show", techname = UrlParameter.Optional }
            );*/

            routes.MapRoute(
                name: "FormAction",
                url: "Form/{techname}/{action}",
                defaults: new { controller = "Form", action = "Show", techname = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index"}
            );

            /*routes.MapRoute(
                name: "Id",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

        }
    }
}