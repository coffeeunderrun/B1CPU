using System.Collections.Generic;
using B1CPU.Assembler.Statements.Types;
using B1CPU.Assembler.Statements.Types.Expressions;
using B1CPU.Core.Instructions;

namespace B1CPU.Assembler.Statements
{
    public interface IStatementFactory
    {
        T Create<T>(IInstruction instruction) where T : IStatement, IInstructionStatement;

        T Create<T>(IList<byte> data) where T : IStatement, IDataStatement;

        T Create<T>(IExpressionStatement leftStatement = null, IExpressionStatement rightStatement = null)
            where T : IStatement, IExpressionStatement;

        T Create<T>(ushort value) where T : IStatement, IValueExpressionStatement;

        T Create<T>(string symbol) where T : IStatement, ISymbolExpressionStatement;
    }
}
