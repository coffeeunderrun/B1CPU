using System.Collections.Generic;
using B1CPU.Assembler.Statements;
using B1CPU.Assembler.Statements.Types;
using B1CPU.Assembler.Statements.Types.Expressions;
using B1CPU.Assembler.Symbols;
using B1CPU.Assembler.Tokens;
using B1CPU.Core.Builder;
using B1CPU.Core.Instructions;

namespace B1CPU.Assembler.Factory
{
    public interface IFactory : Core.Factory.IFactory
    {
        T Create<T>(string content, int row, int column) where T : IToken;

        T Create<T>(string label) where T : IStatement, ILabelStatement;

        T Create<T>(IInstruction instruction) where T : IStatement, IInstructionStatement;

        T Create<T>(IList<byte> data) where T : IStatement, IDataStatement;

        T Create<T>(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            where T : IStatement, IExpressionStatement;

        T Create<T>(ushort value) where T : IStatement, IValueExpressionStatement;

        ISymbol Create(string name, ushort value);

        IBuilder GetTokenMatchBuilder();
    }
}