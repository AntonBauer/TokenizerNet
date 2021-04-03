using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class LetterNumberBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB9";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.IsAHLetter()
            && next.Type == SymbolType.Numeric
                ? false
                : default(bool?);
    }
}
