using B1CPU.Assembler.Lexer;
using B1CPU.Assembler.Parser;
using B1CPU.Assembler.Statements;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Assembler
{
    public sealed class Assembler : IAssembler
    {
        private readonly ILogger _logger;
        private readonly ILexer _lexer;
        private readonly IParser _parser;
        private readonly IStatementRepository _statementRepository;

        public Assembler(ILogger logger, ILexer lexer, IParser parser, IStatementRepository statementRepository)
        {
            _logger = logger;
            _lexer = lexer;
            _parser = parser;
            _statementRepository = statementRepository;
        }

        public bool Assemble(string input, string output)
        {
            if (!_lexer.Tokenize(input))
            {
                _logger.Info("Tokenization failed.");
                return false;
            }

            if (!_parser.Parse())
            {
                _logger.Info("Parsing failed.");
                return false;
            }

            if (!Generate())
            {
                _logger.Info("Code generation failed.");
                return false;
            }

            return true;
        }

        private bool Generate()
        {
            return true;
        }
    }
}