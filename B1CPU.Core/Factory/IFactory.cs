using System;
using B1CPU.Core.Addressing;
using B1CPU.Core.Builder;
using B1CPU.Core.Flags;
using B1CPU.Core.Instructions;
using B1CPU.Core.Registers;

namespace B1CPU.Core.Factory
{
    public interface IFactory
    {
        IFlag Create(string name, int selector);

        T Create<T>(string name, int selector, bool isWordSize) where T : IRegister;

        IInstruction Create(string mnemonic, int opcode, AddressingMode addressingMode,
            Action<byte, AddressingMode, IProcessorState> action, params string[] aliases);

        IInstruction Create(string mnemonic, byte opcode, AddressingMode addressingMode, IRegister register,
            Action<byte, AddressingMode, IProcessorState> action, params string[] aliases);

        IInstruction Create(string mnemonic, byte opcode, AddressingMode addressingMode, IFlag flag,
            Action<byte, AddressingMode, IProcessorState> action, params string[] aliases);

        IBuilder GetFlagBuilder();

        IBuilder GetRegisterBuilder();

        IBuilder GetInstructionBuilder();
    }
}