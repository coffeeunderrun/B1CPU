using System;
using System.Collections.Generic;
using System.Linq;
using B1CPU.Core.Registers.Types;

namespace B1CPU.Core.Registers
{
    public class RegisterRepository : List<IRegister>, IRegisterRepository
    {
        public IRegister this[string name] => this.FirstOrDefault(x => x.Name.Equals(name,
            StringComparison.CurrentCultureIgnoreCase));

        public RegisterRepository(IRegisterFactory factory)
        {
            Add(factory.Create<UserRegister>("A", 0));
            Add(factory.Create<UserRegister>("B", 1));
            Add(factory.Create<UserRegister>("C", 2));
            Add(factory.Create<UserRegister>("X", 3));

            Add(factory.Create<SystemRegister>("F"));

            Add(factory.Create<SystemRegister>("PC", isWordSize: true));
            Add(factory.Create<SystemRegister>("SP", isWordSize: true));
            Add(factory.Create<SystemRegister>("DI", isWordSize: true));
            Add(factory.Create<SystemRegister>("SI", isWordSize: true));

            Add(factory.Create<HiddenRegister>("IR"));
            Add(factory.Create<HiddenRegister>("DB"));
            Add(factory.Create<HiddenRegister>("AB", isWordSize: true));
        }
    }
}
