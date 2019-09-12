using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class NumericBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB8";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.Numeric && next.Type == SymbolType.Numeric ? false : default(bool?);
    }
}
