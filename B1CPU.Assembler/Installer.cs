using B1CPU.Assembler.Assembler;
using B1CPU.Assembler.Lexer;
using B1CPU.Assembler.Parser;
using B1CPU.Assembler.Statements;
using B1CPU.Assembler.Tables;
using B1CPU.Assembler.Tokens;
using B1CPU.Core.Flags;
using B1CPU.Core.Instructions;
using B1CPU.Core.Registers;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace B1CPU.Assembler
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IFlagFactory>().LifestyleSingleton().AsFactory(),
                Component.For<IRegisterFactory>().LifestyleSingleton().AsFactory(),
                Component.For<IInstructionFactory>().LifestyleSingleton().AsFactory(),
                Component.For<ITokenFactory>().LifestyleSingleton().AsFactory(),
                Component.For<IStatementFactory>().LifestyleSingleton().AsFactory(),

                Component.For<IFlagRepository>().ImplementedBy<FlagRepository>().LifestyleSingleton(),
                Component.For<IRegisterRepository>().ImplementedBy<RegisterRepository>().LifestyleSingleton(),
                Component.For<IInstructionRepository>().ImplementedBy<InstructionRepository>().LifestyleSingleton(),
                Component.For<ITokenRepository>().ImplementedBy<TokenRepository>().LifestyleSingleton(),
                Component.For<IStatementRepository>().ImplementedBy<StatementRepository>().LifestyleSingleton(),

                Component.For<ILexer>().ImplementedBy<Lexer.Lexer>().LifestyleSingleton(),
                Component.For<IParser>().ImplementedBy<Parser.Parser>().LifestyleSingleton(),
                Component.For<IAssembler>().ImplementedBy<Assembler.Assembler>().LifestyleSingleton(),

                Component.For<IFlag>().ImplementedBy<Flag>().LifestyleTransient(),
                Component.For<IInstruction>().ImplementedBy<Instruction>().LifestyleTransient(),
                Component.For<ITable>().ImplementedBy<Table>().LifestyleTransient(),

                Classes.FromAssemblyInThisApplication().BasedOn<IRegister>().LifestyleTransient()
                    .Configure(x => x.Named(x.Implementation.FullName)),

                Classes.FromAssemblyInThisApplication().BasedOn<IToken>().LifestyleTransient()
                    .Configure(x => x.Named(x.Implementation.FullName)),

                Classes.FromAssemblyInThisApplication().BasedOn<IStatement>().LifestyleTransient()
                    .Configure(x => x.Named(x.Implementation.FullName))
            );
        }
    }
}