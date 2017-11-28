using System.Text.RegularExpressions;

namespace B1CPU.Assembler.Tokens.Types
{
    public abstract class TokenBase<T> : IToken where T : IToken
    {
        private readonly ITokenFactory _tokenFactory;

        public string Content { get; }

        public int Row { get; }

        public int Column { get; }

        protected abstract Match TryMatch(string text);

        protected TokenBase(ITokenFactory tokenFactory, string content = "", int row = 0, int column = 0)
        {
            _tokenFactory = tokenFactory;
            Content = content;
            Row = row;
            Column = column;
        }

        public bool IsMatch(string text, int row, int column, out IToken token)
        {
            token = null;

            var match = TryMatch(text);

            if (match.Success)
                token = _tokenFactory.Create<T>(match.Value, row, column);

            return match.Success;
        }
    }
}