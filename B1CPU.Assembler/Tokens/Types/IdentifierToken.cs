using System.Text.RegularExpressions;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class IdentifierToken : TokenBase<IdentifierToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^_?[a-z][a-z0-9_]*", RegexOptions.IgnoreCase);

        public IdentifierToken(ITokenFactory tokenFactory, string content = "", int row = 0, int column = 0)
            : base(tokenFactory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}