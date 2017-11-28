namespace B1CPU.Assembler.Statements
{
    public interface IStatement
    {
        IStatement Previous { get; }

        IStatement Next { get; }
    }
}
