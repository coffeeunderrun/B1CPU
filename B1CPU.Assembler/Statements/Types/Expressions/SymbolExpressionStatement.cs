namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class SymbolExpressionStatement : ExpressionStatementBase, ISymbolExpressionStatement
    {
        public string Symbol { get; }

        public SymbolExpressionStatement(string symbol)
        {
            Symbol = symbol;
        }
    }
}