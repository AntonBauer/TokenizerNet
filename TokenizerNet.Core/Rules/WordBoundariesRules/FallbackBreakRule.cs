using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public class FallbackBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB999";

        public bool? AllowBreak(Symbol current, Symbol next) => true;
    }
}
