namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class DivExpressionStatement : ExpressionStatement
    {
        public DivExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}