using System.IO;
using B1CPU.Assembler.Tokens;
using B1CPU.Core.Repository;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Lexer
{
    public sealed class Lexer : ILexer
    {
        private readonly ILogger _logger;
        private readonly IRepository<IToken> _tokens;
        private readonly IRepository<ITokenMatch> _tokenMatches;

        private int _row;
        private int _column;

        public Lexer(ILogger logger, IRepository<IToken> tokens, IRepository<ITokenMatch> tokenMatches)
        {
            _logger = logger;
            _tokens = tokens;
            _tokenMatches = tokenMatches;
        }

        public bool Tokenize(string input)
        {
            if (!File.Exists(input))
            {
                _logger.Error($"Input file does not exist. {input}");
                return false;
            }

            _tokens.Clear();

            using (var reader = File.OpenText(input))
            {
                _row = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _row++;

                    for (_column = 0; _column < line.Length;)
                    {
                        // Skip white spaces
                        if (char.IsWhiteSpace(line[_column]))
                        {
                            _column++;
                            continue;
                        }

                        // Parse what has yet to be parsed
                        var remainder = line.Substring(_column);
                        if (!ParseLine(remainder))
                            return false;
                    }
                }
            }

            return true;
        }

        private bool ParseLine(string line)
        {
            // Iterate through each token type until we have found a match
            foreach (var tokenMatch in _tokenMatches)
            {
                IToken token;
                if (!tokenMatch.IsMatch(line, _row, _column + 1, out token))
                    continue;

                // Return our matched token
                _tokens.Add(token);
                _column += token.Content.Length;

                return true;
            }

            return false;
        }
    }
}