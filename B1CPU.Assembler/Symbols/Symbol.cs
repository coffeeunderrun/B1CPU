namespace B1CPU.Assembler.Symbols
{
    public class Symbol : ISymbol
    {
        public string Name { get; }

        public ushort Value { get; }

        public Symbol(string name, ushort value)
        {
            Name = name;
            Value = value;
        }
    }
}