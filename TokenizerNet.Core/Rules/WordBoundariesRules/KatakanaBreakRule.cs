using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class KatakanaBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB13";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Katakana && next.Type == SymbolType.Katakana ? false : default(bool?);
    }
}
