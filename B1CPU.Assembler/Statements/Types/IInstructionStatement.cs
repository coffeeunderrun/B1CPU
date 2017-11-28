using B1CPU.Core.Instructions;

namespace B1CPU.Assembler.Statements.Types
{
    public interface IInstructionStatement
    {
        IInstruction Instruction { get; }
    }
}