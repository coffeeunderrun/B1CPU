using B1CPU.Assembler.Assembler;
using B1CPU.Assembler.Factory;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace B1CPU.Assembler
{
    internal class Program
    {
        private static void Main()
        {
            // ToDo: Remove hardcoded paths and add application arguments
            using (var container = new WindsorContainer().Install(FromAssembly.InThisApplication()))
            {
                var factory = container.Resolve<IFactory>();
                factory.GetFlagBuilder().Build();
                factory.GetRegisterBuilder().Build();
                factory.GetInstructionBuilder().Build();
                factory.GetTokenMatchBuilder().Build();

                var assembler = container.Resolve<IAssembler>();
                assembler.Assemble(@"C:\Development\test.asm", @"C:\Development\test.bin");

                // We have to release everything we explicitly resolve
                container.Release(assembler);
                container.Release(factory);
            }
        }
    }
}
