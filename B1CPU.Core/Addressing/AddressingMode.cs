namespace B1CPU.Core.Addressing
{
    public enum AddressingMode
    {
        Implied = 0,

        Immediate = AddressingFlag.ByteSizeOperand,

        Absolute = AddressingFlag.WordSizeOperand,

        AbsoluteIndexed = AddressingFlag.WordSizeOperand |
                          AddressingFlag.Indexed,

        AbsoluteIndirect = AddressingFlag.WordSizeOperand |
                           AddressingFlag.Indirect,

        AbsoluteIndirectIndexed = AddressingFlag.WordSizeOperand |
                                  AddressingFlag.PostIndexed |
                                  AddressingFlag.Indirect,

        AbsoluteIndexedIndirect = AddressingFlag.WordSizeOperand |
                                  AddressingFlag.Indexed |
                                  AddressingFlag.Indirect,

        ZeroPage = AddressingFlag.ByteSizeOperand |
                   AddressingFlag.ZeroPage,

        ZeroPageIndexed = AddressingFlag.ByteSizeOperand |
                          AddressingFlag.Indexed |
                          AddressingFlag.ZeroPage,

        ZeroPageIndirect = AddressingFlag.ByteSizeOperand |
                           AddressingFlag.Indirect |
                           AddressingFlag.ZeroPage,

        ZeroPageIndirectIndexed = AddressingFlag.ByteSizeOperand |
                                  AddressingFlag.PostIndexed |
                                  AddressingFlag.Indirect |
                                  AddressingFlag.ZeroPage,

        ZeroPageIndexedIndirect = AddressingFlag.ByteSizeOperand |
                                  AddressingFlag.Indexed |
                                  AddressingFlag.Indirect |
                                  AddressingFlag.ZeroPage
    }
}