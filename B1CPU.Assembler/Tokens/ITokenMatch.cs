namespace B1CPU.Assembler.Tokens
{
    public interface ITokenMatch
    {
        bool IsMatch(string text, int row, int column, out IToken token);
    }
}