namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class ModExpressionStatement : ExpressionStatement
    {
        public ModExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
            : base(leftStatement, rightStatement)
        {
        }
    }
}