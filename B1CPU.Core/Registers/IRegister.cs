namespace B1CPU.Core.Registers
{
    public interface IRegister
    {
        string Name { get; }

        int Selector { get; }

        bool IsWordSize { get; }
    }
}
