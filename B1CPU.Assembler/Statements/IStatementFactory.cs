using B1CPU.Assembler.Tokens;

namespace B1CPU.Assembler.Statements
{
    public interface IStatementFactory
    {
        T Create<T>(IToken token) where T : IStatement;
    }
}
