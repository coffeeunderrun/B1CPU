namespace B1CPU.Core.Flags
{
    public sealed class Flag : IFlag
    {
        public string Name { get; }

        public int Selector { get; }

        public Flag(string name, int selector)
        {
            Name = name;
            Selector = selector;
        }
    }
}
