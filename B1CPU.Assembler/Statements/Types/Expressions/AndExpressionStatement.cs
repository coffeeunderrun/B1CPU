namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class AndExpressionStatement : ExpressionStatement
    {
        public AndExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement) 
            : base(leftStatement, rightStatement)
        {
        }
    }
}