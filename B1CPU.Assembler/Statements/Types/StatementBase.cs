namespace B1CPU.Assembler.Statements.Types
{
    public abstract class StatementBase : IStatement
    {
        public IStatement Previous { get; }

        public IStatement Next { get; }

        protected StatementBase(IStatement previous, IStatement next)
        {
            Previous = previous;
            Next = next;
        }
    }
}
