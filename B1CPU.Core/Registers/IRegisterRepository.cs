using System.Collections.Generic;

namespace B1CPU.Core.Registers
{
    public interface IRegisterRepository : IList<IRegister>
    {
        IRegister this[string name] { get; }
    }
}
