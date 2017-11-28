using System;
using B1CPU.Assembler.Assembler;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace B1CPU.Assembler
{
    internal class Program
    {
        private static void Main()
        {
            using (var container = new WindsorContainer().Install(FromAssembly.This()))
            {
                var assembler = container.Resolve<IAssembler>();
                assembler.Assemble(@"C:\Development\test.asm", @"C:\Development\test.bin");
                Console.ReadLine();
            }
        }
    }
}
