using System.Collections.Generic;
using B1CPU.Core.Addressing;
using B1CPU.Core.Flags;
using B1CPU.Core.Registers;

namespace B1CPU.Core.Instructions
{
    public delegate void InstructionAction(IProcessorState state);

    public interface IInstruction
    {
        string Mnemonic { get; }

        byte Opcode { get; }

        AddressingMode AddressingMode { get; }

        IRegister Register { get; }

        IFlag Flag { get; }

        InstructionAction Execute { get; }

        IList<string> Aliases { get; }
    }
}
