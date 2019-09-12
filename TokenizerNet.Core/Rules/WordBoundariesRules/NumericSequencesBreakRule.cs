using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class NumericSequencesBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB11";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB11
            if ((current.Type == SymbolType.MidNum || current.IsMidNumLetQ()) && next.Type == SymbolType.Numeric)
                return false;

            // WB12
            if (current.Type == SymbolType.Numeric && (next.Type == SymbolType.MidNum || next.IsMidNumLetQ()))
                return false;

            return default;
        }
    }
}
