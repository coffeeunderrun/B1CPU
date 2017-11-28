namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class ValueExpressionStatement : ExpressionStatementBase, IValueExpressionStatement
    {
        public ushort Value { get; }

        public ValueExpressionStatement(ushort value)
        {
            Value = value;
        }
    }
}