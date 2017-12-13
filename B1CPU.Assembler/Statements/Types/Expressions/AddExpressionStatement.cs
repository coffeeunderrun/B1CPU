namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class AddExpressionStatement : ExpressionStatement
    {
        public AddExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}