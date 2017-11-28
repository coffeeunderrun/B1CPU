namespace B1CPU.Core.Registers
{
    public interface IRegisterFactory
    {
        T Create<T>(string name, int selector = -1, bool isWordSize = false) where T : IRegister;
    }
}