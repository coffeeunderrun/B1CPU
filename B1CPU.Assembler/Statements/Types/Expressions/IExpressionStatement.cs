namespace B1CPU.Assembler.Statements.Types.Expressions
{
    public interface IExpressionStatement
    {
        IExpressionStatement LeftStatement { get; set; }

        IExpressionStatement RightStatement { get; set; }
    }
}