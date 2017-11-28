using System.Collections.Generic;

namespace B1CPU.Assembler.Statements
{
    public class StatementRepository : IStatementRepository
    {
        public IList<IStatement> Statements { get; }

        public StatementRepository()
        {
            Statements = new List<IStatement>();
        }
    }
}
