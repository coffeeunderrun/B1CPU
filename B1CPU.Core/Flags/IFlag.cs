using System.Collections.Generic;

namespace B1CPU.Core.Flags
{
    public interface IFlag
    {
        string Name { get; }

        int Selector { get; }
    }
}
