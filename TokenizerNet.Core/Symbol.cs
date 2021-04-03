using TokenizerNet.Core.Enums;

namespace TokenizerNet.Core
{
    public record Symbol
    {
        public CodeSpan Span { get; init; }

        public SymbolType Type { get; init; }

        public string Name { get; init; }
    }
}
