using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class NumberLetterBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB10";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Numeric && next.IsAHLetter() ? false : default(bool?);
    }
}
