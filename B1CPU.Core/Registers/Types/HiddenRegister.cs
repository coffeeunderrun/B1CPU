namespace B1CPU.Core.Registers.Types
{
    public sealed class HiddenRegister : Register
    {
        public HiddenRegister(string name, int selector, bool isWordSize)
            : base(name, selector, isWordSize)
        {
        }
    }
}