using Castle.Facilities.Logging;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Enslam.Site.IoC
{
    public class LoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility("Logging.facility", new LoggingFacility(LoggerImplementation.Log4net));
        }
    }
}