using System;
using B1CPU.Core.Flags;
using B1CPU.Core.Registers;

namespace B1CPU.Core.Instructions
{
    public interface IInstructionFactory
    {
        IInstruction Create(string mnemonic, int opcode, Addressing.Mode addressingMode, Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases);

        IInstruction Create(string mnemonic, byte opcode, Addressing.Mode addressingMode, IRegister register,
            Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases);

        IInstruction Create(string mnemonic, byte opcode, Addressing.Mode addressingMode, IFlag flag,
            Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases);
    }
}