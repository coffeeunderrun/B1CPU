using B1CPU.Core.Builder;
using B1CPU.Core.Factory;
using B1CPU.Core.Flags;
using B1CPU.Core.Instructions;
using B1CPU.Core.Registers;
using B1CPU.Core.Repository;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace B1CPU.Core
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IFactory>().AsFactory(),

                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)),

                Component.For<IFlag>().ImplementedBy<Flag>().LifestyleTransient(),
                Component.For<IInstruction>().ImplementedBy<Instruction>().LifestyleTransient(),

                Classes.FromAssemblyInThisApplication()
                    .BasedOn<IBuilder>()
                    .Configure(x => x.Named(x.Implementation.Name)),

                Classes.FromAssemblyInThisApplication()
                    .BasedOn<IRegister>()
                    .Configure(x => x.Named(x.Implementation.FullName))
                    .LifestyleTransient()
            );
        }
    }
}