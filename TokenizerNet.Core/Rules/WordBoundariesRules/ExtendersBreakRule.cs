using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class ExtendersBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB13";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB13a
            if ((current.IsAHLetter() || current.Type == SymbolType.Numeric || current.Type == SymbolType.Katakana || current.Type == SymbolType.ExtendNumLet) && next.Type == SymbolType.ExtendNumLet)
                return false;

            // WB13b
            if (current.Type == SymbolType.ExtendNumLet && (next.IsAHLetter() || next.Type == SymbolType.Numeric || next.Type == SymbolType.Katakana))
                return false;

            return default;
        }
    }
}
