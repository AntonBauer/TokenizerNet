namespace TokenizerNet.Core.Domain
{
    public struct Symbol
    {
        public static Symbol StartOfText => new Symbol(new CodeSpan(new byte[] { 0, 0 }), SymbolType.StartOfText, "Start of Text");
        public static Symbol EndOfText => new Symbol(new CodeSpan(new byte[] { 255, 255 }), SymbolType.EndOfText, "End of Text");

        public CodeSpan Span { get; }

        public SymbolType Type { get; }

        public string Name { get; }

        public Symbol(CodeSpan span, SymbolType type, string name)
        {
            Span = span;
            Type = type;
            Name = name;
        }

        public Symbol(CodeSpan span) : this(span, SymbolType.Other, "Other") { }
    }
}
