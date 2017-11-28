using System.IO;
using B1CPU.Assembler.Tokens;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Lexer
{
    public sealed class Lexer : ILexer
    {
        private readonly ILogger _logger;
        private readonly ITokenRepository _tokenRepository;

        private int _row;
        private int _column;

        public Lexer(ILogger logger, ITokenRepository tokenRepository)
        {
            _logger = logger;
            _tokenRepository = tokenRepository;
        }

        public bool Tokenize(string input)
        {
            if (!File.Exists(input))
            {
                _logger.Error($"Input file does not exist. {input}");
                return false;
            }

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

                        // Ignore part of the line we already parsed
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
            foreach (var tokenType in _tokenRepository.TokenTypes)
            {
                IToken token;
                if (!tokenType.IsMatch(line, _row, _column + 1, out token))
                    continue;

                _tokenRepository.Add(token);
                _column += token.Content.Length;

                return true;
            }

            return false;
        }
    }
}