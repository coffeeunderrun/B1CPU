namespace B1CPU.Assembler.Symbols
{
    public interface ISymbol
    {
        string Name { get; }

        ushort Value { get; }
    }
}