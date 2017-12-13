using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class DefineToken : Token<DefineToken>
    {
        private static readonly Regex TokenRegex =
            new Regex(@"^db|dw|dd|dq|byte|word|dword|qword", RegexOptions.IgnoreCase);

        public DefineToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}