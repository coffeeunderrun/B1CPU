using System.Text.RegularExpressions;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class DefineToken : TokenBase<DefineToken>
    {
        private static readonly Regex TokenRegex =
            new Regex(@"^db|dw|dd|dq|byte|word|dword|qword", RegexOptions.IgnoreCase);

        public DefineToken(ITokenFactory tokenFactory, string content = "", int row = 0, int column = 0)
            : base(tokenFactory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}