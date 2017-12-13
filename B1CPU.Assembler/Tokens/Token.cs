using System.Text.RegularExpressions;
using B1CPU.Assembler.Factory;

namespace B1CPU.Assembler.Tokens
{
    public abstract class Token<T> : IToken, ITokenMatch where T : IToken
    {
        private readonly IFactory _factory;

        public string Content { get; }

        public int Row { get; }

        public int Column { get; }

        protected abstract Match TryMatch(string text);

        protected Token(IFactory factory, string content, int row, int column)
        {
            _factory = factory;
            Content = content;
            Row = row;
            Column = column;
        }

        public bool IsMatch(string text, int row, int column, out IToken token)
        {
            token = null;

            var match = TryMatch(text);

            if (match.Success)
                token = _factory.Create<T>(match.Value, row, column);

            return match.Success;
        }
    }
}