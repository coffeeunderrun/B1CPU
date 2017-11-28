namespace B1CPU.Core.Registers.Types
{
    public abstract class RegisterBase : IRegister
    {
        public string Name { get; }

        public int Selector { get; }

        public bool IsWordSize { get; }

        protected RegisterBase(string name, int selector = -1, bool isWordSize = false)
        {
            Name = name;
            Selector = selector;
            IsWordSize = isWordSize;
        }
    }
}
