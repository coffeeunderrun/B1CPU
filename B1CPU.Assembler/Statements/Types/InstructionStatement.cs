using B1CPU.Core.Instructions;

namespace B1CPU.Assembler.Statements.Types
{
    public sealed class InstructionStatement : StatementBase, IInstructionStatement
    {
        public IInstruction Instruction { get; }

        public InstructionStatement(IInstruction instruction)
        {
            Instruction = instruction;
        }
    }
}