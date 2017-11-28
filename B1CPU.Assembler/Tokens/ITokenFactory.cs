namespace B1CPU.Assembler.Tokens
{
    public interface ITokenFactory
    {
        T Create<T>(string content = "", int row = 0, int column = 0) where T : IToken;
    }
}