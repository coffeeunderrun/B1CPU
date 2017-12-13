using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class AssignToken : Token<AssignToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^=|equ", RegexOptions.IgnoreCase);

        public AssignToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}