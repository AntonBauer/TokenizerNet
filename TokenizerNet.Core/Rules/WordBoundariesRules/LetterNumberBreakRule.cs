using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class LetterNumberBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB9";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.IsAHLetter() && next.Type == SymbolType.Numeric ? false : default(bool?);
    }
}
