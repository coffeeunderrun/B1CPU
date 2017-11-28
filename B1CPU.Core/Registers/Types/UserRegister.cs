namespace B1CPU.Core.Registers.Types
{
    public class UserRegister : RegisterBase
    {
        public UserRegister(string name, int selector = -1, bool isWordSize = false)
            : base(name, selector, isWordSize)
        {
        }
    }
}