using System.Text.RegularExpressions;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class AssignToken : TokenBase<AssignToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^=|equ", RegexOptions.IgnoreCase);

        public AssignToken(ITokenFactory tokenFactory, string content = "", int row = 0, int column = 0)
            : base(tokenFactory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}