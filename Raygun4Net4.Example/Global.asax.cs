using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mindscape.Raygun4Net;
using Mindscape.Raygun4Net.Messages;

namespace WebApplication1
{
    public class MvcApplication : HttpApplication, IRaygunApplication
    {
        private static RaygunClient _raygunClient;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //    protected void Application_BeginRequest()
        //    {
        //      _raygunClient.ContextId = $"ThreadCorrelationApp-{Guid.NewGuid().ToString().Substring(0, 8)}";
        //      
        //      // Done in config
        //      //_raygunClient.ApplicationVersion = "1.3.37.0";
        //      
        //      _raygunClient.UserInfo = new RaygunIdentifierMessage("jnorman@raygun.io")
        //      {
        //        IsAnonymous = false,
        //        FullName = "Jeremy Norman",
        //        FirstName = "Jeremy",
        //        Email = "jnorman@raygun.io"
        //      };
        //    }

        public RaygunClient GenerateRaygunClient()
        {
            if (_raygunClient == null)
            {
                InitialiseRaygunClient();
            }

            _raygunClient.ContextId = $"ThreadCorrelationApp-{Guid.NewGuid().ToString().Substring(0, 8)}";

            _raygunClient.UserInfo = new RaygunIdentifierMessage("jnorman@raygun.io")
            {
                IsAnonymous = false,
                FullName = "Jeremy Norman",
                FirstName = "Jeremy",
                Email = "jnorman@raygun.io"
            };

            return _raygunClient;
        }

        private void InitialiseRaygunClient()
        {
            _raygunClient = new RaygunClient();
            //_raygunClient.AddWrapperExceptions(typeof(AggregateException));
            _raygunClient.ApplicationVersion = "1.3.37.0";
        }
    }
}