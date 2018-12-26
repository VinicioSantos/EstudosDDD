////using Microsoft.Owin;
////using Microsoft.Owin.Security.OAuth;
////using Owin;
////using SpaUserControl.API.Security;
////using SpaUserControl.Domain.Contracts.Services;
////using SpaUserControl.Startupp;
////using System;
////using System.Web.Http;
////using Unity;
//using Microsoft.Owin;
//using Microsoft.Owin.Security.OAuth;
//using Microsoft.Practices.Unity;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using Owin;
//using SpaUserControl.Api.Security;
//using SpaUserControl.API.Helpers;
////using SpaUserControl.API.Security;
//using SpaUserControl.Domain.Contracts.Services;
//using SpaUserControl.Startupp;
//using System;
//using System.Web.Http;
//using Unity;

//namespace SpaUserControl.API
//{
//    public class Startup
//    {

//        public void Configuration(IAppBuilder app)
//        {

//            HttpConfiguration config = new HttpConfiguration();

//            //var container = new UnityContainer();
//            Unity.UnityContainer container = new Unity.UnityContainer();//Microsoft.Practices.Unity.UnityContainer();
//            //DependencyResolver.Resolver(container);
//            //config.DependencyResolver = new Unityresolver(container);
//            DependencyResolver.Resolve(container);
//            config.DependencyResolver = new Unityresolver(container);

//            ConfigureWebApi(config);
//            COnfigurationOAuth(app, container.Resolve<IUserServices>());

//            //Deixar o serviço publico
//            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
//            app.UseWebApi(config);
//        }


//        public static void ConfigureWebApi(HttpConfiguration config)
//        {
//            config.MapHttpAttributeRoutes();



//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//                );
//        }

//        //Metodo de autenticação do serviço
//        public void COnfigurationOAuth(IAppBuilder app, IUserServices service)
//        {
//            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
//            {
//                AllowInsecureHttp = true,//permite chamadas inseguras(não https)
//                TokenEndpointPath = new PathString("/api/security/token"),//passa um token
//                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),//expira em 2 horas
//                Provider = new AuthorizationServerProvider(service)
//            };

//            //Token Geração
//            app.UseOAuthAuthorizationServer(OAuthServerOptions);
//            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

//        }
//    }
//}
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SpaUserControl.API.Helpers;
using SpaUserControl.Api.Security;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Startupp;
using System;
using System.Web.Http;
//using Unity;
//using Microsoft.Practices.Unity;

namespace SpaUserControl.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configure Dependency Injection
            //var container = new Microsoft.Practices.Unity.UnityContainer();
            UnityContainer container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new Unityresolver(container);

            ConfigureWebApi(config);
            ConfigureOAuth(app, container.Resolve<IUserServices>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Remove o XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            // Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void ConfigureOAuth(IAppBuilder app, IUserServices service)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(service)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}