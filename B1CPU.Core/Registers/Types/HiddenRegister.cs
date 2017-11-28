namespace B1CPU.Core.Registers.Types
{
    public class HiddenRegister : RegisterBase
    {
        public HiddenRegister(string name, int selector = -1, bool isWordSize = false)
            : base(name, selector, isWordSize)
        {
        }
    }
}