using System;
using System.Collections.Generic;
using System.Linq;

namespace B1CPU.Core.Flags
{
    public class FlagRepository : List<IFlag>, IFlagRepository
    {
        public IFlag this[string name] => this.FirstOrDefault(x => x.Name.Equals(name,
            StringComparison.CurrentCultureIgnoreCase));

        public FlagRepository(IFlagFactory factory)
        {
            Add(factory.Create("C", 0));
            Add(factory.Create("V", 1));
            Add(factory.Create("S", 2));
            Add(factory.Create("Z", 3));

            Add(factory.Create("H"));
            Add(factory.Create("I"));
        }
    }
}
