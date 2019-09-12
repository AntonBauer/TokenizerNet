using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class AcrossPunctuationsBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB7";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB 7
            if ((current.Type == SymbolType.MidLetter || current.IsMidNumLetQ()) && next.IsAHLetter())
                return false;

            // WB7a
            if (current.Type == SymbolType.HebrewLetter && next.Type == SymbolType.HebrewLetter)
                return false;

            // WB7b
            if (current.Type == SymbolType.HebrewLetter && next.Type == SymbolType.DoubleQuote)
                return false;

            // WB7c
            if (current.Type == SymbolType.DoubleQuote && next.Type == SymbolType.HebrewLetter)
                return false;

            return default;
        }
    }
}
