using System.Collections.Generic;

namespace B1CPU.Assembler.Statements
{
    public interface IStatementRepository
    {
        IList<IStatement> Statements { get; }
    }
}
