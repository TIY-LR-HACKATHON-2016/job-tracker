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
                new {controller = "Users", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Jobs", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}