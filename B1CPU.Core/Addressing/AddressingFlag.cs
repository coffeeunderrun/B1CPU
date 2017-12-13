using System;

namespace B1CPU.Core.Addressing
{
    [Flags]
    public enum AddressingFlag
    {
        ByteSizeOperand = 1,
        WordSizeOperand = 1 << 1,
        Indirect = 1 << 2,
        Indexed = 1 << 3,
        PostIndexed = 1 << 4,
        ZeroPage = 1 << 5
    }
}