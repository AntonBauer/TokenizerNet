using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
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
            if (current.Type.IsNewLine() || next.Type.IsNewLine())
                return true;

            // WB3d
            if (current.Type == SymbolType.WSegSpace && next.Type == SymbolType.WSegSpace)
                return false;

            return default;
        }
    }
}
