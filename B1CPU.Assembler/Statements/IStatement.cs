namespace B1CPU.Assembler.Statements
{
    public interface IStatement
    {
        IStatement Previous { get; set; }

        IStatement Next { get; set; }
    }
}
