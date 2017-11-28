using System.Collections.Generic;

namespace B1CPU.Core.Instructions
{
    public interface IInstructionRepository : IList<IInstruction>
    {
        IInstruction Find(string mnemonic, Addressing.Mode mode);

        IInstruction Find(string mnemonic, int mode);
    }
}