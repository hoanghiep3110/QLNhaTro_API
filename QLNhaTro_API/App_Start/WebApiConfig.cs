using System.Web.Http;

namespace QLNhaTro_API.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "GetAllRoom",
            //    routeTemplate: "api/get-room",
            //    defaults: new { controller = "PHONG", action = "Get" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "GetRoomtDetail",
            //    routeTemplate: "api/room-detail/{id}",
            //    defaults: new { controller = "PHONG", action = "Get" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "EditRoom",
            //    routeTemplate: "api/put/{id}",
            //    defaults: new { controller = "PHONG", action = "Put" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "AddRoom",
            //    routeTemplate: "api/post",
            //    defaults: new { controller = "PHONG", action = "Post" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "DeleteRoom",
            //    routeTemplate: "api/delete/{id}",
            //    defaults: new { controller = "PHONG", action = "Delete" }
            //);
        }
    }
}