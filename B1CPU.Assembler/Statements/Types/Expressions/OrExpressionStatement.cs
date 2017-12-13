namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class OrExpressionStatement : ExpressionStatement
    {
        public OrExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}