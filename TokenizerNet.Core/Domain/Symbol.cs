namespace TokenizerNet.Core.Domain
{
    public struct Symbol
    {
        public SymbolType Type { get; }

        public Symbol(SymbolType type)
        {
            Type = type;
        }
    }
}
