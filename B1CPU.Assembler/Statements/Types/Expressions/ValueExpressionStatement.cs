namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class ValueExpressionStatement : ExpressionStatement, IValueExpressionStatement
    {
        public ushort Value { get; }

        public ValueExpressionStatement(ushort value) : base(null, null)
        {
            Value = value;
        }
    }
}