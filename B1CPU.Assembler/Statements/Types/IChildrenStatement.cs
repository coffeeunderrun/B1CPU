using System.Collections.Generic;

namespace B1CPU.Assembler.Statements.Types
{
    public interface IChildrenStatement
    {
        IList<IStatement> Children { get; }
    }
}