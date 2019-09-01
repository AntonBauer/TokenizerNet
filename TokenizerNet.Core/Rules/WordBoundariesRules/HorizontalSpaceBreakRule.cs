using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class HorizontalSpaceBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB3d";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.WSegSpace && next.Type == SymbolType.WSegSpace ? false : default(bool?);
    }
}
