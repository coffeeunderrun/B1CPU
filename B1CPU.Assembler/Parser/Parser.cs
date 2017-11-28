using B1CPU.Assembler.Statements;
using B1CPU.Assembler.Tables;
using B1CPU.Assembler.Tokens;
using B1CPU.Core;
using B1CPU.Core.Instructions;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Parser
{
    public class Parser : IParser
    {
        private readonly ILogger _logger;
        private readonly IInstructionRepository _instructionRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IStatementFactory _statementFactory;
        private readonly IStatementRepository _statementRepository;
        private readonly ITable _symbolTable;
        private readonly ITable _labelTable;

        public Parser(ILogger logger, IInstructionRepository instructionRepository, ITokenRepository tokenRepository,
            IStatementFactory statementFactory, IStatementRepository statementRepository, ITable symbolTable,
            ITable labelTable)
        {
            _logger = logger;
            _instructionRepository = instructionRepository;
            _tokenRepository = tokenRepository;
            _statementFactory = statementFactory;
            _statementRepository = statementRepository;
            _symbolTable = symbolTable;
            _labelTable = labelTable;
        }

        public bool Parse()
        {
            return true;
        }
    }
}