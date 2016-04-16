using System.Web.Mvc;
using System.Web.Routing;

namespace JobTracker.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "users", action = "about", id = UrlParameter.Optional}
                );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "jobs", action = "about", id = UrlParameter.Optional }
                );
        }
    }
}