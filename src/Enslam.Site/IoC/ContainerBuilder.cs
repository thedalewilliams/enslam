using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Enslam.Site.IoC
{
    public static class ContainerBuilder
    {
        public static IWindsorContainer Build(string configPath)
        {
            var container = new WindsorContainer(new XmlInterpreter(configPath));

            // automatically register controllers
            container.Register(AllTypes
                                   .Of<Controller>()
                                   .FromAssembly(Assembly.GetExecutingAssembly())
                                   .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name.ToLower())));

            return container;
        }
    }
}