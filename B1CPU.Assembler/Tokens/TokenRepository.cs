using System.Collections.Generic;
using B1CPU.Assembler.Tokens.Types;

namespace B1CPU.Assembler.Tokens
{
    public sealed class TokenRepository : List<IToken>, ITokenRepository
    {
        public IEnumerable<IToken> TokenTypes { get; }

        public TokenRepository(ITokenFactory tokenFactory)
        {
            TokenTypes = new List<IToken>
            {
                // Order matters
                tokenFactory.Create<AssignToken>(),
                tokenFactory.Create<DefineToken>(),
                tokenFactory.Create<LabelToken>(),
                tokenFactory.Create<ChildLabelToken>(),
                tokenFactory.Create<IdentifierToken>(),

                // Order does not matter
                tokenFactory.Create<CharToken>(),
                tokenFactory.Create<CloseBracketToken>(),
                tokenFactory.Create<CommaToken>(),
                tokenFactory.Create<CommentToken>(),
                tokenFactory.Create<DecimalToken>(),
                tokenFactory.Create<HexToken>(),
                tokenFactory.Create<LiteralToken>(),
                tokenFactory.Create<OpenBracketToken>(),
                tokenFactory.Create<OperatorToken>(),
                tokenFactory.Create<StringToken>(),
                tokenFactory.Create<UnknownToken>()
            };
        }
    }
}
