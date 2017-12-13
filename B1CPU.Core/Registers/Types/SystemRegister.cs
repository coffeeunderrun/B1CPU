namespace B1CPU.Core.Registers.Types
{
    public sealed class SystemRegister : Register
    {
        public SystemRegister(string name, int selector, bool isWordSize)
            : base(name, selector, isWordSize)
        {
        }
    }
}