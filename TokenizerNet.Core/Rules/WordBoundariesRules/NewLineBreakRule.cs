using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public class NewLineBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB3";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB3
            if (current.Type == SymbolType.CarriageReturn && next.Type == SymbolType.LineFinish)
                return false;

            // WB3a, WB3b
            if (IsNewLine(current.Type) || IsNewLine(next.Type))
                return true;

            // WB3d
            if (current.Type == SymbolType.WSegSpace && next.Type == SymbolType.WSegSpace)
                return false;

            return default;
        }

        public bool IsNewLine(SymbolType type) =>
            type == SymbolType.CarriageReturn
            || type == SymbolType.LineFinish
            || type == SymbolType.NewLine;
    }
}
