using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class KatakanaBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB13";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Katakana
            && next.Type == SymbolType.Katakana
                ? false
                : default(bool?);
    }
}
