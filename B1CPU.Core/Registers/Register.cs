namespace B1CPU.Core.Registers
{
    public abstract class Register : IRegister
    {
        public string Name { get; }

        public int Selector { get; }

        public bool IsWordSize { get; }

        protected Register(string name, int selector, bool isWordSize)
        {
            Name = name;
            Selector = selector;
            IsWordSize = isWordSize;
        }
    }
}
