using System.Collections.Generic;

namespace B1CPU.Assembler.Statements.Types
{
    public sealed class LabelStatement : Statement, ILabelStatement, IChildrenStatement
    {
        public string Label { get; }

        public IList<IStatement> Children { get; }

        public LabelStatement(string label)
        {
            Label = label;
            Children = new List<IStatement>();
        }
    }
}