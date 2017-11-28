namespace B1CPU.Core.Registers.Types
{
    public sealed class HiddenRegister : RegisterBase
    {
        public HiddenRegister(string name, int selector = -1, bool isWordSize = false)
            : base(name, selector, isWordSize)
        {
        }
    }
}