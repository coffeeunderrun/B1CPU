namespace B1CPU.Assembler.Tokens
{
    public interface IToken
    {
        string Content { get; }

        int Row { get; }

        int Column { get; }
    }
}
