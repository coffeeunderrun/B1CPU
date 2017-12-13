using B1CPU.Assembler.Lexer;
using B1CPU.Assembler.Parser;
using B1CPU.Assembler.Statements;
using B1CPU.Core.Repository;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Assembler
{
    public sealed class Assembler : IAssembler
    {
        private readonly ILogger _logger;
        private readonly ILexer _lexer;
        private readonly IParser _parser;
        private readonly IRepository<IStatement> _statements;

        public Assembler(ILogger logger, ILexer lexer, IParser parser, IRepository<IStatement> statements)
        {
            _logger = logger;
            _lexer = lexer;
            _parser = parser;
            _statements = statements;
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