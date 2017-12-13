using System.Collections.Generic;

namespace B1CPU.Assembler.Statements.Types
{
    public sealed class DataStatement : Statement, IDataStatement
    {
        public IList<byte> Data { get; }

        public DataStatement(IList<byte> data)
        {
            Data = data;
        }
    }
}