using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class UnknownToken : Token<UnknownToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^\S+", RegexOptions.IgnoreCase);

        public UnknownToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}