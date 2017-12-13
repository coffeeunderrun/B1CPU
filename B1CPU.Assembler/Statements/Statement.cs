namespace B1CPU.Assembler.Statements
{
    public abstract class Statement : IStatement
    {
        public IStatement Previous { get; set; }

        public IStatement Next { get; set; }
    }
}
