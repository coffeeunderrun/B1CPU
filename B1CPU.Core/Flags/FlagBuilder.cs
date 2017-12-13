using B1CPU.Core.Builder;
using B1CPU.Core.Factory;
using B1CPU.Core.Repository;

namespace B1CPU.Core.Flags
{
    public class FlagBuilder : IBuilder
    {
        private readonly IFactory _factory;
        private readonly IRepository<IFlag> _repository;

        public FlagBuilder(IFactory factory, IRepository<IFlag> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Build()
        {
            _repository.Add(_factory.Create("C", 0));
            _repository.Add(_factory.Create("V", 1));
            _repository.Add(_factory.Create("S", 2));
            _repository.Add(_factory.Create("Z", 3));

            _repository.Add(_factory.Create("H", -1));
            _repository.Add(_factory.Create("I", -1));
        }
    }
}