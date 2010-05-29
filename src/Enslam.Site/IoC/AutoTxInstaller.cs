using Castle.Facilities.AutoTx;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Enslam.Site.IoC
{
    public class AutoTxInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility("AutoTx.facility", new TransactionFacility());
        }
    }
}