using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class BetweenLettersBreakingRule : IBreakRule
    {
        public string UnicodeStandardId => "WB5";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.IsAHLetter() && next.IsAHLetter()
                ? false
                : default(bool?);
    }
}
