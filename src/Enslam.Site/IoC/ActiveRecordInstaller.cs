using Castle.Facilities.ActiveRecordIntegration;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Enslam.Site.IoC
{
    public class ActiveRecordInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility("ActiveRecord.facility", new ActiveRecordFacility());
        }
    }
}