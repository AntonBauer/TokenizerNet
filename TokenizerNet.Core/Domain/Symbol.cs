namespace TokenizerNet.Core.Domain
{
    public struct Symbol
    {
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
