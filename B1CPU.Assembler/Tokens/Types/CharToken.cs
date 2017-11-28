using System.Text.RegularExpressions;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class CharToken : TokenBase<CharToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^'[^']'", RegexOptions.IgnoreCase);

        public CharToken(ITokenFactory tokenFactory, string content = "", int row = 0, int column = 0)
            : base(tokenFactory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}