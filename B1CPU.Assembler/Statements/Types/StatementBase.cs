namespace B1CPU.Assembler.Statements.Types
{
    public abstract class StatementBase : IStatement
    {
        public IStatement Previous { get; set; }

        public IStatement Next { get; set; }
    }
}
