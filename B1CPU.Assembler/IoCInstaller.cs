using B1CPU.Assembler.Assembler;
using B1CPU.Assembler.Factory;
using B1CPU.Assembler.Lexer;
using B1CPU.Assembler.Parser;
using B1CPU.Assembler.Statements;
using B1CPU.Assembler.Tokens;
using B1CPU.Core.Builder;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace B1CPU.Assembler
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IFactory>().AsFactory(),
          
                Component.For<ILexer>().ImplementedBy<Lexer.Lexer>(),
                Component.For<IParser>().ImplementedBy<Parser.Parser>(),
                Component.For<IAssembler>().ImplementedBy<Assembler.Assembler>(),

                Classes.FromAssemblyInThisApplication()
                    .BasedOn<IBuilder>()
                    .Configure(x => x.Named(x.Implementation.Name)),

                Classes.FromAssemblyInThisApplication()
                    .BasedOn<IToken>()
                    .Configure(x => x.Named(x.Implementation.Name))
                    .LifestyleTransient(),

                Classes.FromAssemblyInThisApplication()
                    .BasedOn<IStatement>()
                    .Configure(x => x.Named(x.Implementation.Name))
                    .LifestyleTransient()
            );
        }
    }
}