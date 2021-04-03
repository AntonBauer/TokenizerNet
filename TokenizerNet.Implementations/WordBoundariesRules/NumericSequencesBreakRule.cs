using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class NumericSequencesBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB11";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB11
            if (next.Type == SymbolType.Numeric && (current.Type == SymbolType.MidNum || current.IsMidNumLetQ()))
                return false;

            // WB12
            if (current.Type == SymbolType.Numeric && (next.Type == SymbolType.MidNum || next.IsMidNumLetQ()))
                return false;

            return default;
        }
    }
}
