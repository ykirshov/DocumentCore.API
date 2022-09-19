using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DocumentCore.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Converter",
                url: "{controller}/{action}",
                defaults: new { controller = "Converter", action = "ConvertToPdf" }
            );
        }
    }
}
