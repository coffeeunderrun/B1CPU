using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using B1CPU.Assembler.Factory;
using B1CPU.Assembler.Statements;
using B1CPU.Assembler.Statements.Types;
using B1CPU.Assembler.Symbols;
using B1CPU.Assembler.Tokens;
using B1CPU.Assembler.Tokens.Types;
using B1CPU.Core.Instructions;
using B1CPU.Core.Repository;
using Castle.Core.Logging;

namespace B1CPU.Assembler.Parser
{
    public sealed class Parser : IParser
    {
        private readonly ILogger _logger;
        private readonly IFactory _factory;
        private readonly IRepository<IInstruction> _instructions;
        private readonly IRepository<IToken> _tokens;
        private readonly IRepository<IStatement> _statements;
        private readonly IRepository<ISymbol> _symbols;

        private int _tokenIndex;

        private IStatement CurrentLabel { get; set; }

        private IStatement CurrentStatement { get; set; }

        private IToken CurrentToken { get; set; }

        private IToken AdvanceToken => CurrentToken = _tokens.ElementAtOrDefault(_tokenIndex++);

        private IToken PeekNextToken => _tokens.ElementAtOrDefault(_tokenIndex);

        private IToken PeekPrevToken => _tokens.ElementAtOrDefault(_tokenIndex - 1);

        public Parser(ILogger logger, IFactory factory, IRepository<IInstruction> instructions,
            IRepository<IToken> tokens, IRepository<IStatement> statements, IRepository<ISymbol> symbols)
        {
            _logger = logger;
            _factory = factory;
            _instructions = instructions;
            _tokens = tokens;
            _statements = statements;
            _symbols = symbols;
        }

        public bool Parse()
        {
            _statements.Clear();

            _tokenIndex = 0;

            CurrentToken = null;
            CurrentStatement = null;
            CurrentLabel = null;

            while (AdvanceToken != null)
            {
                if (CurrentToken is CommentToken)
                    continue;

                if ((CurrentToken is LabelToken || CurrentToken is ChildLabelToken) && ParseLabel())
                    continue;

                if (CurrentToken is IdentifierToken && ParseIdentifier())
                    continue;

                if (CurrentToken is DefineToken && ParseDefine())
                    continue;

                // Error
                return false;
            }

            return true;
        }

        private bool ParseLabel()
        {
            if (!(CurrentToken is LabelToken) && !(CurrentToken is ChildLabelToken))
                return false;

            if (_symbols.Any(x => x.Name.Equals(CurrentToken.Content)))
            {
                _logger.Error($"'{CurrentToken.Content}' already defined. ({CurrentToken.Row}, {CurrentToken.Column})");
                return false;
            }

            if (CurrentToken is LabelToken)
            {
                var label = _factory.Create<LabelStatement>(CurrentToken.Content);
                _statements.Add(CurrentLabel = label);
                return true;
            }

            if (CurrentLabel == null)
                _statements.Add(CurrentLabel = _factory.Create<LabelStatement>("Global"));

            var currentLabel = CurrentLabel as LabelStatement;
            if (currentLabel == null)
                return false;

            var childLabel = _factory.Create<LabelStatement>($"{currentLabel.Label}{CurrentToken.Content}");
            currentLabel.Children.Add(childLabel);

            return true;
        }

        private bool ParseSymbol()
        {
            if (!(CurrentToken is IdentifierToken))
                return false;

            if (_symbols.Any(x => x.Name.Equals(CurrentToken.Content)))
            {
                _logger.Error($"'{CurrentToken.Content}' already defined. ({CurrentToken.Row}, {CurrentToken.Column})");
                return false;
            }

            var symbolToken = CurrentToken;

            if (!(AdvanceToken is AssignToken))
                return false;

            ushort value;
            if (!TryParseValue(AdvanceToken, out value))
                return false;

            _symbols.Add(_factory.Create(symbolToken.Content, value));

            return true;
        }

        private bool ParseExpression()
        {
            return true;
        }

        private bool ParseInstruction()
        {
            if (!(CurrentToken is IdentifierToken))
                return false;

            var mode = 0;

            //if (PeekNextToken is OpenBracketToken)

            return true;
        }

        private bool ParseIdentifier()
        {
            if (!(CurrentToken is IdentifierToken))
                return false;

            return
                false; //_instructionRepository.Find(CurrentToken.Content) != null ? ParseInstruction() : ParseSymbol();
        }

        private bool ParseDefine()
        {
            if (!(CurrentToken is DefineToken))
                return false;

            var data = new List<byte>();

            while (PeekNextToken is StringToken || PeekNextToken is CharToken ||
                   PeekNextToken is DecimalToken || PeekNextToken is HexToken)
            {
                if (PeekNextToken is StringToken)
                    data.AddRange(Encoding.ASCII.GetBytes(AdvanceToken.Content.Replace(@"""", "")));

                if (PeekNextToken is CharToken)
                    data.AddRange(Encoding.ASCII.GetBytes(AdvanceToken.Content.Replace(@"'", "")));

                ushort value;
                if (!TryParseValue(AdvanceToken, out value))
                    continue;

                data.Add((byte)((value >> 8) & 0xFF));
                data.Add((byte)(value & 0xFF));
            }

            var dataStatement = _factory.Create<DataStatement>(data);

            if (CurrentStatement == null)
            {
                _statements.Add(CurrentStatement = dataStatement);
                return true;
            }

            dataStatement.Previous = CurrentStatement;
            CurrentStatement = CurrentStatement.Next = dataStatement;

            return true;
        }

        private bool TryParseValue(IToken token, out ushort value)
        {
            value = 0;

            if (token is DecimalToken)
                return ushort.TryParse(CurrentToken.Content, out value);

            if (token is HexToken)
                return ushort.TryParse(CurrentToken.Content.Replace("$", ""), NumberStyles.HexNumber,
                    CultureInfo.CurrentCulture, out value);

            return false;
        }
    }
}