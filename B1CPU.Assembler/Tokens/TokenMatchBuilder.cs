using B1CPU.Assembler.Factory;
using B1CPU.Assembler.Tokens.Types;
using B1CPU.Core.Builder;
using B1CPU.Core.Repository;

namespace B1CPU.Assembler.Tokens
{
    public class TokenMatchBuilder : IBuilder
    {
        private readonly IFactory _factory;
        private readonly IRepository<ITokenMatch> _repository;

        public TokenMatchBuilder(IFactory factory, IRepository<ITokenMatch> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Build()
        {
            // Order matters
            _repository.Add(_factory.Create<AssignToken>("", 0, 0));
            _repository.Add(_factory.Create<DefineToken>("", 0, 0));
            _repository.Add(_factory.Create<LabelToken>("", 0, 0));
            _repository.Add(_factory.Create<ChildLabelToken>("", 0, 0));
            _repository.Add(_factory.Create<IdentifierToken>("", 0, 0));

            // Order does not matter
            _repository.Add(_factory.Create<CharToken>("", 0, 0));
            _repository.Add(_factory.Create<CloseBracketToken>("", 0, 0));
            _repository.Add(_factory.Create<CommaToken>("", 0, 0));
            _repository.Add(_factory.Create<CommentToken>("", 0, 0));
            _repository.Add(_factory.Create<DecimalToken>("", 0, 0));
            _repository.Add(_factory.Create<HexToken>("", 0, 0));
            _repository.Add(_factory.Create<LiteralToken>("", 0, 0));
            _repository.Add(_factory.Create<OpenBracketToken>("", 0, 0));
            _repository.Add(_factory.Create<OperatorToken>("", 0, 0));
            _repository.Add(_factory.Create<StringToken>("", 0, 0));
            _repository.Add(_factory.Create<UnknownToken>("", 0, 0));
        }
    }
}