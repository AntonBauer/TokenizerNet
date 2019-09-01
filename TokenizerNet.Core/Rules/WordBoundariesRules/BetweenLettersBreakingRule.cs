using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class BetweenLettersBreakingRule : IBreakRule
    {
        public string UnicodeStandardId => "WB5";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.IsAHLetter() && next.IsAHLetter() ? false : default(bool?); 
    }
}
