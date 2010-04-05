using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.ActiveRecord;
using Castle.Windsor;
using Enslam.Site.IoC;
using MvcContrib.Castle;
using MvcContrib.ControllerFactories;

namespace Enslam.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            InitializeWindsor();

            ActiveRecordStarter.UpdateSchema();

        }

        /// <summary>
        /// This web application uses the Castle Project's IoC _container, Windsor see:
        /// http://www.castleproject.org/_container/index.html
        /// </summary>
        protected virtual void InitializeWindsor()
        {
            if (_container == null)
            {
                // create a new Windsor Container
                _container = ContainerBuilder.Build(@"Configuration/Windsor.config");
                // set the controller factory to the Windsor controller factory (in MVC Contrib)
                System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory(new WindsorDependencyResolver(_container)));
            }
        }
    }
}