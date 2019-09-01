using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules
{
    public static class Macroses
    {
        public static bool IsAHLetter(this Symbol symbol) =>
            symbol.Type == SymbolType.ALetter || symbol.Type == SymbolType.HebrewLetter;

        public static bool IsMidNumLetQ(this Symbol symbol) =>
            symbol.Type == SymbolType.MidNumLet || symbol.Type == SymbolType.SingleQuote;
    }
}
