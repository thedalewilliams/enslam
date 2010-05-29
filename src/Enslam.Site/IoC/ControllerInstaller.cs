using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Enslam.Site.IoC
{
    public class ControllerInstaller : IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes
                .Of<Controller>()
                .FromAssembly(Assembly.GetExecutingAssembly())
                .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name.ToLower())));
        }
    }
}