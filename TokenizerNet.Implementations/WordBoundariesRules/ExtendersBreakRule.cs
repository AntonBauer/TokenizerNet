using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.WordBoundariesRules
{
    public sealed class ExtendersBreakRule : IBreakRule
    {
        public string UnicodeStandardId => "WB13";

        public bool? AllowBreak(Symbol current, Symbol next)
        {
            // WB13a
            if (next.Type == SymbolType.ExtendNumLet &&
                (current.IsAHLetter()
                 || current.Type == SymbolType.Numeric
                 || current.Type == SymbolType.Katakana
                 || current.Type == SymbolType.ExtendNumLet
                ))
                return false;

            // WB13b
            if (current.Type == SymbolType.ExtendNumLet &&
                (next.IsAHLetter()
                 || next.Type == SymbolType.Numeric
                 || next.Type == SymbolType.Katakana
               ))
               return false;

            return default;
        }
    }
}
