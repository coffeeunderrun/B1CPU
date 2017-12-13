using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class ChildLabelToken : Token<ChildLabelToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^\._?[a-z][a-z0-9_]*:", RegexOptions.IgnoreCase);

        public ChildLabelToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}