using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class NumberLetterBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB10";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Numeric && next.IsAHLetter()
                ? false
                : default(bool?);
    }
}
