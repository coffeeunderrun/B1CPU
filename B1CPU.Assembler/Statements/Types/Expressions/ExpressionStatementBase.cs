namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public abstract class ExpressionStatementBase : StatementBase, IExpressionStatement
    {
        public IExpressionStatement LeftStatement { get; set; }

        public IExpressionStatement RightStatement { get; set; }

        protected ExpressionStatementBase(IExpressionStatement leftStatement = null,
            IExpressionStatement rightStatement = null)
        {
            LeftStatement = leftStatement;
            RightStatement = rightStatement;
        }
    }
}