using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Enslam.Common.Repositories;

namespace Enslam.Common.IoC
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>))
                    .LifeStyle.Transient
            );
        }
    }
}