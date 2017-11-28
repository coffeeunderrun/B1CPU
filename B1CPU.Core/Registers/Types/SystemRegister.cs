namespace B1CPU.Core.Registers.Types
{
    public sealed class SystemRegister : RegisterBase
    {
        public SystemRegister(string name, int selector = -1, bool isWordSize = false)
            : base(name, selector, isWordSize)
        {
        }
    }
}