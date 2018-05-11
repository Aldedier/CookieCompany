using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CookieCompany.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductoIdJson",
                url: "pjson/{id}",
                defaults: new { controller = "Utils", action = "ObtenerProductosId" }
            );

            routes.MapRoute(
                name: "ProductoJson",
                url: "pjson",
                defaults: new { controller = "Utils", action = "ObtenerProductos" }
            );

            routes.MapRoute(
                name: "ProductoDetalles",
                url: "Hola/{id}",
                defaults: new { controller = "Producto", action = "Details" },
                constraints: new { id = "[0-9]+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
