namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class MulExpressionStatement : ExpressionStatement
    {
        public MulExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}