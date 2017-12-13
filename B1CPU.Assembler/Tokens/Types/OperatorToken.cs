using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class OperatorToken : Token<OperatorToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^\+|-|\*|\\|%|&|\||\^", RegexOptions.IgnoreCase);

        public OperatorToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}