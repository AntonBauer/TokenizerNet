using TokenizerNet.Core;

namespace TokenizerNet.Implementations.Models
{
    internal record SymbolsPair
    {
        public Symbol Current { get; init; }

        public Symbol Next { get; init; }
    }
}
