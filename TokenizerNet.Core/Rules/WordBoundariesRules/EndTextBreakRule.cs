using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public class EndTextBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB2";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            next.Type == SymbolType.EndOfText ? true : default;
    }
}
