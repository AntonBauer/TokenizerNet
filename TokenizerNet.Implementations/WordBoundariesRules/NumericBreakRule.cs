using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class NumericBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB8";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Numeric
            && next.Type == SymbolType.Numeric
                ? false
                : default(bool?);
    }
}
