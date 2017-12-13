using B1CPU.Core.Builder;
using B1CPU.Core.Factory;
using B1CPU.Core.Registers.Types;
using B1CPU.Core.Repository;

namespace B1CPU.Core.Registers
{
    public class RegisterBuilder : IBuilder
    {
        private readonly IFactory _factory;
        private readonly IRepository<IRegister> _repository;

        public RegisterBuilder(IFactory factory, IRepository<IRegister> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Build()
        {
            _repository.Add(_factory.Create<UserRegister>("A", 0, false));
            _repository.Add(_factory.Create<UserRegister>("B", 1, false));
            _repository.Add(_factory.Create<UserRegister>("C", 2, false));
            _repository.Add(_factory.Create<UserRegister>("X", 3, false));

            _repository.Add(_factory.Create<SystemRegister>("F", -1, false));
            _repository.Add(_factory.Create<SystemRegister>("PC", -1, true));
            _repository.Add(_factory.Create<SystemRegister>("SP", -1, true));
            _repository.Add(_factory.Create<SystemRegister>("DI", -1, true));
            _repository.Add(_factory.Create<SystemRegister>("SI", -1, true));

            _repository.Add(_factory.Create<HiddenRegister>("IR", -1, false));
            _repository.Add(_factory.Create<HiddenRegister>("DB", -1, false));
            _repository.Add(_factory.Create<HiddenRegister>("AB", -1, true));
        }
    }
}