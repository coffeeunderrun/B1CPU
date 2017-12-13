using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens.Types
{
    public sealed class DecimalToken : Token<DecimalToken>
    {
        private static readonly Regex TokenRegex = new Regex(@"^[0-9]+", RegexOptions.IgnoreCase);

        public DecimalToken(IFactory factory, string content, int row, int column)
            : base(factory, content, row, column)
        {
        }

        protected override Match TryMatch(string text) => TokenRegex.Match(text);
    }
}