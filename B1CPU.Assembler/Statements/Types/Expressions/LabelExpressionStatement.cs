namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public sealed class LabelExpressionStatement : ExpressionStatement, ILabelStatement
    {
        public string Label { get; }

        public LabelExpressionStatement(string label) : base(null, null)
        {
            Label = label;
        }
    }
}