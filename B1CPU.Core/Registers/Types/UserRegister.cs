namespace B1CPU.Core.Registers.Types
{
    public sealed class UserRegister : Register
    {
        public UserRegister(string name, int selector, bool isWordSize)
            : base(name, selector, isWordSize)
        {
        }
    }
}