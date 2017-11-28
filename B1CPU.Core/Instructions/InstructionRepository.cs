using System;
using System.Collections.Generic;
using System.Linq;
using B1CPU.Core.Flags;
using B1CPU.Core.Registers;

namespace B1CPU.Core.Instructions
{
    public class InstructionRepository : List<IInstruction>, IInstructionRepository
    {
        public InstructionRepository(IInstructionFactory factory, IRegisterRepository registerRepository,
            IFlagRepository flagRepository)
        {
            Add(factory.Create("NOOP", 0x00, Addressing.Mode.Implied, ChangeFlagEx));
            Add(factory.Create("CLRI", 0x01, Addressing.Mode.Implied, ChangeFlagEx));
            Add(factory.Create("HALT", 0x04, Addressing.Mode.Implied, ChangeFlagEx));
            Add(factory.Create("SETI", 0x05, Addressing.Mode.Implied, ChangeFlagEx));

            Add(factory.Create("RETN", 0x10, Addressing.Mode.Implied, Return));
            Add(factory.Create("SBRK", 0x14, Addressing.Mode.Implied, Break));
            Add(factory.Create("LDSP", 0x18, Addressing.Mode.Absolute, LoadStackPointer));
            Add(factory.Create("STSP", 0x1C, Addressing.Mode.Implied, StoreStackPointer));
            Add(factory.Create("PSHF", 0x20, Addressing.Mode.Implied, PushF));
            Add(factory.Create("POPF", 0x24, Addressing.Mode.Implied, PopF));

            Add(factory.Create("JPN", 0x38, Addressing.Mode.Absolute, flagRepository["C"], ConditionalJump));
            Add(factory.Create("JPN", 0x38, Addressing.Mode.Absolute, flagRepository["V"], ConditionalJump));
            Add(factory.Create("JPN", 0x38, Addressing.Mode.Absolute, flagRepository["S"], ConditionalJump, "JMPL"));
            Add(factory.Create("JPN", 0x38, Addressing.Mode.Absolute, flagRepository["Z"], ConditionalJump, "JPNE"));

            Add(factory.Create("JMP", 0x3C, Addressing.Mode.Absolute, flagRepository["C"], ConditionalJump));
            Add(factory.Create("JMP", 0x3C, Addressing.Mode.Absolute, flagRepository["V"], ConditionalJump));
            Add(factory.Create("JMP", 0x3C, Addressing.Mode.Absolute, flagRepository["S"], ConditionalJump, "JPGE"));
            Add(factory.Create("JMP", 0x3C, Addressing.Mode.Absolute, flagRepository["Z"], ConditionalJump, "JMPE"));

            Add(factory.Create("CLN", 0x40, Addressing.Mode.Absolute, flagRepository["C"], ConditionalCall));
            Add(factory.Create("CLN", 0x40, Addressing.Mode.Absolute, flagRepository["V"], ConditionalCall));
            Add(factory.Create("CLN", 0x40, Addressing.Mode.Absolute, flagRepository["S"], ConditionalCall, "CLLL"));
            Add(factory.Create("CLN", 0x40, Addressing.Mode.Absolute, flagRepository["Z"], ConditionalCall, "CLNE"));

            Add(factory.Create("CLL", 0x44, Addressing.Mode.Absolute, flagRepository["C"], ConditionalCall));
            Add(factory.Create("CLL", 0x44, Addressing.Mode.Absolute, flagRepository["V"], ConditionalCall));
            Add(factory.Create("CLL", 0x44, Addressing.Mode.Absolute, flagRepository["S"], ConditionalCall, "CLGE"));
            Add(factory.Create("CLL", 0x44, Addressing.Mode.Absolute, flagRepository["Z"], ConditionalCall, "CLLE"));

            Add(factory.Create("STOS", 0xF0, Addressing.Mode.Implied, StoreSource));
            Add(factory.Create("LODD", 0xF4, Addressing.Mode.Implied, LoadDestination));
            Add(factory.Create("STSD", 0xF8, Addressing.Mode.Implied, SourceToDestination));

            Add(factory.Create("STOA", 0x70, Addressing.Mode.IndirectIndexed, Store));
            Add(factory.Create("LODA", 0x74, Addressing.Mode.IndirectIndexed, Load));
            Add(factory.Create("STOA", 0x78, Addressing.Mode.ZeroPageIndirectIndexed, Store));
            Add(factory.Create("LODA", 0x7C, Addressing.Mode.ZeroPageIndirectIndexed, Load));

            for (var sel = 0; sel < 4; sel++)
            {
                var flg = flagRepository[sel];
                var reg = registerRepository[sel];

                byte opcode = 0x08;
                Add(factory.Create("CLR", opcode, Addressing.Mode.Implied, flg, ChangeFlag));
                Add(factory.Create("SET", opcode += 4, Addressing.Mode.Implied, flg, ChangeFlag));

                opcode = 0x80;
                Add(factory.Create("CMP", opcode, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("ADD", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("SUB", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("MUL", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("DIV", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("AND", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("ORR", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("XOR", opcode += 4, Addressing.Mode.Immediate, reg, ArithmeticLogicTwoInput));

                Add(factory.Create("CMP", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("ADD", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("SUB", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("MUL", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("DIV", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("AND", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("ORR", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));
                Add(factory.Create("XOR", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicTwoInput));

                Add(factory.Create("NEG", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("NOT", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("SHL", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("SHR", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("ROL", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("ROR", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("INC", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));
                Add(factory.Create("DEC", opcode += 4, Addressing.Mode.Implied, reg, ArithmeticLogicOneInput));

                Add(factory.Create("LOD", opcode += 4, Addressing.Mode.Immediate, reg, Load));
                Add(factory.Create("LOD", opcode += 4, Addressing.Mode.Implied, reg, Load));
                Add(factory.Create("STO", opcode += 4, Addressing.Mode.Implied, reg, Store));
                Add(factory.Create("PSH", opcode += 4, Addressing.Mode.Implied, reg, Push));
                Add(factory.Create("POP", opcode += 4, Addressing.Mode.Implied, reg, Pop));
            }

            for (var i = 0; i < 2; i++)
            {
                var mode = i == 1 ? Addressing.Mode.AbsoluteIndexed : Addressing.Mode.Absolute;

                byte opcode = 0x28;
                Add(factory.Create("LDDI", opcode, mode, LoadDestinationIndex));
                Add(factory.Create("LDSI", opcode += 4, mode, LoadSourceIndex));

                opcode = 0x48;
                Add(factory.Create("JUMP", opcode, mode, Jump));
                Add(factory.Create("CALL", opcode += 4, mode, Call));
                Add(factory.Create("CALL", opcode += 4, mode, Call));
                Add(factory.Create("LODA", opcode += 4, mode, Load));
                Add(factory.Create("STOA", opcode += 4, mode, Store));
                Add(factory.Create("LODA", opcode += 4, mode, Load));
                Add(factory.Create("STOA", opcode += 4, mode, Store));

                mode = i == 1 ? Addressing.Mode.IndexedIndirect : Addressing.Mode.Indirect;
                Add(factory.Create("LODA", opcode += 4, mode, Load));
                Add(factory.Create("STOA", opcode += 4, mode, Store));

                mode = i == 1 ? Addressing.Mode.ZeroPageIndexedIndirect : Addressing.Mode.ZeroPageIndirect;
                Add(factory.Create("LODA", opcode += 4, mode, Load));
                Add(factory.Create("STOA", opcode += 4, mode, Store));
            }
        }

        public IInstruction Find(string mnemonic, Addressing.Mode mode)
        {
            return this.FirstOrDefault(
                x => x.Mnemonic.Equals(mnemonic, StringComparison.CurrentCultureIgnoreCase) &&
                     x.AddressingMode == mode);
        }

        public IInstruction Find(string mnemonic, int mode)
        {
            return Find(mnemonic, (Addressing.Mode)Enum.ToObject(typeof(Addressing.Mode), mode));
        }

        #region Execution Actions

        private static void ChangeFlag(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Flags |= (byte)(((op & 4) >> 2) << (op & 3));
        }

        private static void ChangeFlagEx(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Flags |= (byte)(((op & 4) >> 2) << (4 + (op & 1)));
        }

        private static void Jump(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter);

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void Call(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.Write(state.StackPointer--, (byte)(state.ProgramCounter & 0xFF));
            state.Write(state.StackPointer--, (byte)((state.ProgramCounter >> 8) & 0xFF));

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void ConditionalJump(byte op, Addressing.Mode mode, IProcessorState state)
        {
            if ((state.Flags & (((op & 4) >> 2) << (op & 3))) != 0)
                Jump(op, mode, state);
        }

        private static void ConditionalCall(byte op, Addressing.Mode mode, IProcessorState state)
        {
            if ((state.Flags & (((op & 4) >> 2) << (op & 3))) != 0)
                Call(op, mode, state);
        }

        private static void Return(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var hi = state.Read(--state.StackPointer);
            var lo = state.Read(--state.StackPointer);

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void Break(byte op, Addressing.Mode mode, IProcessorState state)
        {
        }

        private static void Load(byte op, Addressing.Mode mode, IProcessorState state)
        {
        }

        private static void Store(byte op, Addressing.Mode mode, IProcessorState state)
        {
        }

        private static void LoadStackPointer(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.StackPointer = (byte)((hi << 8) | lo);
        }

        private static void StoreStackPointer(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Registers[0] = (byte)(state.StackPointer & 0xFF);
        }

        private static void LoadDestinationIndex(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.DestinationIndex = (byte)((hi << 8) | lo);
        }

        private static void LoadSourceIndex(byte op, Addressing.Mode mode, IProcessorState state)
        {
            byte lo = state.Read(state.ProgramCounter++);
            byte hi = state.Read(state.ProgramCounter++);

            state.SourceIndex = (byte)((hi << 8) | lo);
        }

        private static void StoreSource(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Registers[0] = state.Read(state.SourceIndex++);
        }

        private static void LoadDestination(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(state.DestinationIndex++, state.Registers[0]);
        }

        private static void SourceToDestination(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(state.DestinationIndex++, state.Read(state.SourceIndex++));
        }

        private static void Push(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(state.StackPointer--, state.Registers[op & 3]);
        }

        private static void Pop(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(++state.StackPointer, state.Registers[op & 3]);
        }

        private static void PushF(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(state.StackPointer--, state.Flags);
        }

        private static void PopF(byte op, Addressing.Mode mode, IProcessorState state)
        {
            state.Write(++state.StackPointer, state.Flags);
        }

        private static void ArithmeticLogicTwoInput(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var val1 = state.Registers[op & 3];
            var val2 = mode == Addressing.Mode.Immediate ? state.Read(state.ProgramCounter++) : state.Registers[0];
            var result = 0;

            var alu = (op & 0x1C) >> 2;
            switch (alu)
            {
                case 0: // CMP
                case 2: // SUB
                    result = val1 - val2;
                    break;
                case 1: // ADD
                    result = val1 + val2;
                    break;
                case 3: // MUL
                    result = val1 * val2;
                    break;
                case 4: // DIV
                    result = val1 / val2;
                    break;
                case 5: // AND
                    result = val1 & val2;
                    break;
                case 6: // OR
                    result = val1 | val2;
                    break;
                case 7: // XOR
                    result = val1 ^ val2;
                    break;
            }

            if (alu > 0)
                state.Registers[0] = (byte)result;
        }

        private static void ArithmeticLogicOneInput(byte op, Addressing.Mode mode, IProcessorState state)
        {
            var reg = op & 3;
            var alu = (op & 0x1C) >> 2;
            switch (alu)
            {
                case 0: // NEG
                    state.Registers[reg] = (byte)-state.Registers[reg];
                    break;
                case 1: // NOT
                    state.Registers[reg] = (byte)~state.Registers[reg];
                    break;
                case 2: // SHL
                    state.Registers[reg] = (byte)(state.Registers[reg] << 1);
                    break;
                case 3: // SHR
                    state.Registers[reg] = (byte)(state.Registers[reg] >> 1);
                    break;
                case 4: // ROL
                    state.Registers[reg] = (byte)(state.Registers[reg] << 1 | (state.Flags & 1));
                    break;
                case 5: // ROR
                    state.Registers[reg] = (byte)(state.Registers[reg] >> 1 | ((state.Flags & 1) << 7));
                    break;
                case 6: // INC
                    state.Registers[reg]++;
                    break;
                case 7: // DEC
                    state.Registers[reg]--;
                    break;
            }
        }

        #endregion Execution Actions
    }
}