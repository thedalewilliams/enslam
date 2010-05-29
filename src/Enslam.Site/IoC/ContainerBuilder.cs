using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Enslam.Common.IoC;

namespace Enslam.Site.IoC
{
    public static class ContainerBuilder
    {
        public static IWindsorContainer Build()
        {
            var container = new WindsorContainer(new XmlInterpreter("Windsor.config"));
            
            container.Install(
                new LoggingInstaller(),
                new AutoTxInstaller(),
                new ActiveRecordInstaller(),
                new ControllerInstaller(),
                new RepositoryInstaller()
            );

            return container;
        }
    }
}