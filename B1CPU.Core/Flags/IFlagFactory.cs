namespace B1CPU.Core.Flags
{
    public interface IFlagFactory
    {
        IFlag Create(string name, int selector = -1);
    }
}
