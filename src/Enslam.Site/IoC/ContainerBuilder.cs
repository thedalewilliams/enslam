using System.Reflection;
using System.Web.Mvc;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Enslam.Common.Repositories;

namespace Enslam.Site.IoC
{
    public static class ContainerBuilder
    {
        public static IWindsorContainer Build()
        {
            var container = new WindsorContainer(new XmlInterpreter(new ConfigResource()));

            // automatically register controllers
            container.Register(AllTypes
                                   .Of<Controller>()
                                   .FromAssembly(Assembly.GetExecutingAssembly())
                                   .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name.ToLower())));

            container.Register(
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (Repository<>)).LifeStyle.Transient
            );

            return container;
        }
    }
}