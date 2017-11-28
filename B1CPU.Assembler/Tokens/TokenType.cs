namespace B1CPU.Assembler.Tokens
{
    public enum TokenType
    {
        Unknown,
        Comment,    // Ignored
        Define,     // Statement
        Label,      // Symbol
        Identifier, // Instruction or Symbol
        Literal,
        Decimal,
        Hex,
        Assign,
        Add,
        Subtract,
        Comma,
        Open,
        Close,
        Char,
        String
    }
}
