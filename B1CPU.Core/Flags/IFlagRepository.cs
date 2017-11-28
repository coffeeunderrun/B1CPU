using System.Collections.Generic;

namespace B1CPU.Core.Flags
{
    public interface IFlagRepository : IList<IFlag>
    {
        IFlag this[string name] { get; }
    }
}
