using System;
using System.Collections.Generic;
using B1CPU.Core.Flags;
using B1CPU.Core.Registers;

namespace B1CPU.Core.Instructions
{
    public sealed class Instruction : IInstruction
    {
        public string Mnemonic { get; }

        public byte Opcode { get; }

        public Addressing.Mode AddressingMode { get; }

        public IRegister Register { get; }

        public IFlag Flag { get; }

        public InstructionAction Execute { get; }

        public IList<string> Aliases { get; }

        public Instruction(string mnemonic, byte opcode, Addressing.Mode addressingMode,
            Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases)
        {
            Mnemonic = mnemonic;
            Opcode = opcode;
            AddressingMode = addressingMode;
            Execute = state => action(opcode, addressingMode, state);
            Aliases = new List<string>(aliases);
        }

        public Instruction(string mnemonic, byte opcode, Addressing.Mode addressingMode, IRegister register,
            Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases)
            : this(mnemonic + register.Name, (byte)(opcode + register.Selector), addressingMode, action, aliases)
        {
            Register = register;
        }

        public Instruction(string mnemonic, byte opcode, Addressing.Mode addressingMode, IFlag flag,
            Action<byte, Addressing.Mode, IProcessorState> action, params string[] aliases)
            : this(mnemonic + flag.Name, (byte)(opcode + flag.Selector), addressingMode, action, aliases)
        {
            Flag = flag;
        }
    }
}