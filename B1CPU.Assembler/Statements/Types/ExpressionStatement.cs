namespace B1CPU.Assembler.Statements.Types
{
    public abstract class ExpressionStatement : Statement, IExpressionStatement
    {
        public IExpressionStatement LeftStatement { get; set; }

        public IExpressionStatement RightStatement { get; set; }

        protected ExpressionStatement(IExpressionStatement leftStatement, IExpressionStatement rightStatement)
        {
            LeftStatement = leftStatement;
            RightStatement = rightStatement;
        }
    }
}