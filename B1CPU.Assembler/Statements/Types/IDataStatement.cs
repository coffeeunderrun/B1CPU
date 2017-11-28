using System.Collections.Generic;

namespace B1CPU.Assembler.Statements.Types
{
    public interface IDataStatement
    {
        IList<byte> Data { get; }
    }
}