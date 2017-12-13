namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class SubExpressionStatement : ExpressionStatement
    {
        public SubExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}