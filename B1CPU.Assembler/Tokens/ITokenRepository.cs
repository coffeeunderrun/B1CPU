using System.Collections.Generic;

namespace B1CPU.Assembler.Tokens
{
    public interface ITokenRepository : IList<IToken>
    {
        IEnumerable<IToken> TokenTypes { get; }
    }
}
