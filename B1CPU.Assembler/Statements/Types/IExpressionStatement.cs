namespace B1CPU.Assembler.Statements.Types
{
    public interface IExpressionStatement
    {
        IExpressionStatement LeftStatement { get; set; }

        IExpressionStatement RightStatement { get; set; }
    }
}