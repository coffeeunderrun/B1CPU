namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class XorExpressionStatement : ExpressionStatement
    {
        public XorExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}