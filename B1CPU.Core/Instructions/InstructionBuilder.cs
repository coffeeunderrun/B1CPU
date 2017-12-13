using B1CPU.Core.Addressing;
using B1CPU.Core.Builder;
using B1CPU.Core.Factory;
using B1CPU.Core.Flags;
using B1CPU.Core.Registers;
using B1CPU.Core.Repository;

namespace B1CPU.Core.Instructions
{
    public class InstructionBuilder : IBuilder
    {
        private readonly IFactory _factory;
        private readonly IRepository<IInstruction> _repository;
        private readonly IRepository<IFlag> _flags;
        private readonly IRepository<IRegister> _registers;

        public InstructionBuilder(IFactory factory, IRepository<IInstruction> repository, IRepository<IFlag> flags,
            IRepository<IRegister> registers)
        {
            _factory = factory;
            _repository = repository;
            _flags = flags;
            _registers = registers;
        }

        public void Build()
        {
            _repository.Add(_factory.Create("NOOP", 0x00, AddressingMode.Implied, ChangeFlagEx));
            _repository.Add(_factory.Create("CLRI", 0x01, AddressingMode.Implied, ChangeFlagEx));
            _repository.Add(_factory.Create("HALT", 0x04, AddressingMode.Implied, ChangeFlagEx));
            _repository.Add(_factory.Create("SETI", 0x05, AddressingMode.Implied, ChangeFlagEx));

            _repository.Add(_factory.Create("RETN", 0x10, AddressingMode.Implied, Return));
            _repository.Add(_factory.Create("SBRK", 0x14, AddressingMode.Implied, Break));
            _repository.Add(_factory.Create("LDSP", 0x18, AddressingMode.Absolute, LoadStackPointer));
            _repository.Add(_factory.Create("STSP", 0x1C, AddressingMode.Implied, StoreStackPointer));
            _repository.Add(_factory.Create("PSHF", 0x20, AddressingMode.Implied, PushF));
            _repository.Add(_factory.Create("POPF", 0x24, AddressingMode.Implied, PopF));

            _repository.Add(_factory.Create("JPN", 0x38, AddressingMode.Absolute, _flags[0], ConditionalJump));
            _repository.Add(_factory.Create("JPN", 0x38, AddressingMode.Absolute, _flags[1], ConditionalJump));
            _repository.Add(_factory.Create("JPN", 0x38, AddressingMode.Absolute, _flags[2], ConditionalJump, "JMPL"));
            _repository.Add(_factory.Create("JPN", 0x38, AddressingMode.Absolute, _flags[3], ConditionalJump, "JPNE"));

            _repository.Add(_factory.Create("JMP", 0x3C, AddressingMode.Absolute, _flags[0], ConditionalJump));
            _repository.Add(_factory.Create("JMP", 0x3C, AddressingMode.Absolute, _flags[1], ConditionalJump));
            _repository.Add(_factory.Create("JMP", 0x3C, AddressingMode.Absolute, _flags[2], ConditionalJump, "JPGE"));
            _repository.Add(_factory.Create("JMP", 0x3C, AddressingMode.Absolute, _flags[3], ConditionalJump, "JMPE"));

            _repository.Add(_factory.Create("CLN", 0x40, AddressingMode.Absolute, _flags[0], ConditionalCall));
            _repository.Add(_factory.Create("CLN", 0x40, AddressingMode.Absolute, _flags[1], ConditionalCall));
            _repository.Add(_factory.Create("CLN", 0x40, AddressingMode.Absolute, _flags[2], ConditionalCall, "CLLL"));
            _repository.Add(_factory.Create("CLN", 0x40, AddressingMode.Absolute, _flags[3], ConditionalCall, "CLNE"));

            _repository.Add(_factory.Create("CLL", 0x44, AddressingMode.Absolute, _flags[0], ConditionalCall));
            _repository.Add(_factory.Create("CLL", 0x44, AddressingMode.Absolute, _flags[1], ConditionalCall));
            _repository.Add(_factory.Create("CLL", 0x44, AddressingMode.Absolute, _flags[2], ConditionalCall, "CLGE"));
            _repository.Add(_factory.Create("CLL", 0x44, AddressingMode.Absolute, _flags[3], ConditionalCall, "CLLE"));

            _repository.Add(_factory.Create("STOS", 0xF0, AddressingMode.Implied, StoreSource));
            _repository.Add(_factory.Create("LODD", 0xF4, AddressingMode.Implied, LoadDestination));
            _repository.Add(_factory.Create("STSD", 0xF8, AddressingMode.Implied, SourceToDestination));

            _repository.Add(_factory.Create("STOA", 0x70, AddressingMode.AbsoluteIndirectIndexed, Store));
            _repository.Add(_factory.Create("LODA", 0x74, AddressingMode.AbsoluteIndirectIndexed, Load));
            _repository.Add(_factory.Create("STOA", 0x78, AddressingMode.ZeroPageIndirectIndexed, Store));
            _repository.Add(_factory.Create("LODA", 0x7C, AddressingMode.ZeroPageIndirectIndexed, Load));

            for (var sel = 0; sel < 4; sel++)
            {
                var flg = _flags[sel];
                var reg = _registers[sel];

                byte opcode = 0x08;
                _repository.Add(_factory.Create("CLR", opcode, AddressingMode.Implied, flg, ChangeFlag));
                _repository.Add(_factory.Create("SET", opcode += 4, AddressingMode.Implied, flg, ChangeFlag));

                opcode = 0x80;
                _repository.Add(_factory.Create("CMP", opcode, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("ADD", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("SUB", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("MUL", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("DIV", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("AND", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("ORR", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));
                _repository.Add(_factory.Create("XOR", opcode += 4, AddressingMode.Immediate, reg, AluTwoInput));

                _repository.Add(_factory.Create("CMP", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("ADD", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("SUB", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("MUL", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("DIV", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("AND", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("ORR", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));
                _repository.Add(_factory.Create("XOR", opcode += 4, AddressingMode.Implied, reg, AluTwoInput));

                _repository.Add(_factory.Create("NEG", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("NOT", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("SHL", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("SHR", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("ROL", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("ROR", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("INC", opcode += 4, AddressingMode.Implied, reg, AluOneInput));
                _repository.Add(_factory.Create("DEC", opcode += 4, AddressingMode.Implied, reg, AluOneInput));

                _repository.Add(_factory.Create("LOD", opcode += 4, AddressingMode.Immediate, reg, Load));
                _repository.Add(_factory.Create("LOD", opcode += 4, AddressingMode.Implied, reg, Load));
                _repository.Add(_factory.Create("STO", opcode += 4, AddressingMode.Implied, reg, Store));
                _repository.Add(_factory.Create("PSH", opcode += 4, AddressingMode.Implied, reg, Push));
                _repository.Add(_factory.Create("POP", opcode += 4, AddressingMode.Implied, reg, Pop));
            }

            for (var i = 0; i < 2; i++)
            {
                var mode = i == 1 ? AddressingMode.AbsoluteIndexed : AddressingMode.Absolute;

                byte opcode = 0x28;
                _repository.Add(_factory.Create("LDDI", opcode, mode, LoadDestinationIndex));
                _repository.Add(_factory.Create("LDSI", opcode += 4, mode, LoadSourceIndex));

                opcode = 0x48;
                _repository.Add(_factory.Create("JUMP", opcode, mode, Jump));
                _repository.Add(_factory.Create("CALL", opcode += 4, mode, Call));
                _repository.Add(_factory.Create("CALL", opcode += 4, mode, Call));
                _repository.Add(_factory.Create("LODA", opcode += 4, mode, Load));
                _repository.Add(_factory.Create("STOA", opcode += 4, mode, Store));
                _repository.Add(_factory.Create("LODA", opcode += 4, mode, Load));
                _repository.Add(_factory.Create("STOA", opcode += 4, mode, Store));

                mode = i == 1 ? AddressingMode.AbsoluteIndexedIndirect : AddressingMode.AbsoluteIndirect;
                _repository.Add(_factory.Create("LODA", opcode += 4, mode, Load));
                _repository.Add(_factory.Create("STOA", opcode += 4, mode, Store));

                mode = i == 1 ? AddressingMode.ZeroPageIndexedIndirect : AddressingMode.ZeroPageIndirect;
                _repository.Add(_factory.Create("LODA", opcode += 4, mode, Load));
                _repository.Add(_factory.Create("STOA", opcode += 4, mode, Store));
            }
        }

        #region Execution Actions

        private static void ChangeFlag(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Flags |= (byte)(((op & 4) >> 2) << (op & 3));
        }

        private static void ChangeFlagEx(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Flags |= (byte)(((op & 4) >> 2) << (4 + (op & 1)));
        }

        private static void Jump(byte op, AddressingMode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter);

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void Call(byte op, AddressingMode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.Write(state.StackPointer--, (byte)(state.ProgramCounter & 0xFF));
            state.Write(state.StackPointer--, (byte)((state.ProgramCounter >> 8) & 0xFF));

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void ConditionalJump(byte op, AddressingMode mode, IProcessorState state)
        {
            if ((state.Flags & (((op & 4) >> 2) << (op & 3))) != 0)
                Jump(op, mode, state);
        }

        private static void ConditionalCall(byte op, AddressingMode mode, IProcessorState state)
        {
            if ((state.Flags & (((op & 4) >> 2) << (op & 3))) != 0)
                Call(op, mode, state);
        }

        private static void Return(byte op, AddressingMode mode, IProcessorState state)
        {
            var hi = state.Read(--state.StackPointer);
            var lo = state.Read(--state.StackPointer);

            state.ProgramCounter = (byte)((hi << 8) | lo);
        }

        private static void Break(byte op, AddressingMode mode, IProcessorState state)
        {
        }

        private static void Load(byte op, AddressingMode mode, IProcessorState state)
        {
        }

        private static void Store(byte op, AddressingMode mode, IProcessorState state)
        {
        }

        private static void LoadStackPointer(byte op, AddressingMode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.StackPointer = (byte)((hi << 8) | lo);
        }

        private static void StoreStackPointer(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Registers[0] = (byte)(state.StackPointer & 0xFF);
        }

        private static void LoadDestinationIndex(byte op, AddressingMode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.DestinationIndex = (byte)((hi << 8) | lo);
        }

        private static void LoadSourceIndex(byte op, AddressingMode mode, IProcessorState state)
        {
            var lo = state.Read(state.ProgramCounter++);
            var hi = state.Read(state.ProgramCounter++);

            state.SourceIndex = (byte)((hi << 8) | lo);
        }

        private static void StoreSource(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Registers[0] = state.Read(state.SourceIndex++);
        }

        private static void LoadDestination(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(state.DestinationIndex++, state.Registers[0]);
        }

        private static void SourceToDestination(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(state.DestinationIndex++, state.Read(state.SourceIndex++));
        }

        private static void Push(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(state.StackPointer--, state.Registers[op & 3]);
        }

        private static void Pop(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(++state.StackPointer, state.Registers[op & 3]);
        }

        private static void PushF(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(state.StackPointer--, state.Flags);
        }

        private static void PopF(byte op, AddressingMode mode, IProcessorState state)
        {
            state.Write(++state.StackPointer, state.Flags);
        }

        private static void AluTwoInput(byte op, AddressingMode mode, IProcessorState state)
        {
            var val1 = state.Registers[op & 3];
            var val2 = mode == AddressingMode.Immediate ? state.Read(state.ProgramCounter++) : state.Registers[0];
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
                default:
                    break;
            }

            // Don't store CMP result
            if (alu > 0)
                state.Registers[0] = (byte)result;
        }

        private static void AluOneInput(byte op, AddressingMode mode, IProcessorState state)
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
                default:
                    break;
            }
        }

        #endregion Execution Actions
    }
}