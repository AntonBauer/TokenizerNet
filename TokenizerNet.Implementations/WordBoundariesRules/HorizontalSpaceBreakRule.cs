using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class HorizontalSpaceBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB3d";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            current.Type == SymbolType.WSegSpace
            && next.Type == SymbolType.WSegSpace
                ? false
                : default(bool?);
    }
}
