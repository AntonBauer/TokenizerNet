using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public class StartTextBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB1";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.StartOfText ? true : default;
    }
}
