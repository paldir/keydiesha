using System.Web.Mvc;
using System.Web.Routing;

namespace Kdsh.Zamówienia
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Sklepy", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}