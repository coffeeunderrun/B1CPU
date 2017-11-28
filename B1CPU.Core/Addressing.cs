namespace B1CPU.Core
{
    public static class Addressing
    {
        public const int ByteSizeOperand = 1;
        public const int WordSizeOperand = 1 << 1;
        public const int Indirect = 1 << 2;
        public const int Indexed = 1 << 3;
        public const int PostIndexed = 1 << 4;
        public const int ZeroPage = ByteSizeOperand | 1 << 5;

        public enum Mode
        {
            Implied,
            Immediate = ByteSizeOperand,
            Absolute = WordSizeOperand,
            AbsoluteIndexed = WordSizeOperand | Indexed,
            Indirect = WordSizeOperand | Addressing.Indirect,
            IndirectIndexed = WordSizeOperand | PostIndexed | Addressing.Indirect,
            IndexedIndirect = WordSizeOperand | Indexed | Addressing.Indirect,
            ZeroPage = Addressing.ZeroPage,
            ZeroPageIndexed = Indexed | Addressing.ZeroPage,
            ZeroPageIndirect = Addressing.Indirect | Addressing.ZeroPage,
            ZeroPageIndirectIndexed = PostIndexed | Addressing.Indirect | Addressing.ZeroPage,
            ZeroPageIndexedIndirect = Indexed | Addressing.Indirect | Addressing.ZeroPage
        }
    }
}