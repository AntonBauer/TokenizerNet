using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;
using TokenizerNet.Implementations.Models;

namespace TokenizerNet.Implementations.Extensions
{
    internal static class SymbolExtensions
    {
        public static bool IsAHLetter(this Symbol symbol) =>
            symbol.Type == SymbolType.ALetter || symbol.Type == SymbolType.HebrewLetter;

        public static bool IsMidNumLetQ(this Symbol symbol) =>
            symbol.Type == SymbolType.MidNumLet || symbol.Type == SymbolType.SingleQuote;

        public static SymbolsPair ToSymbolPair(this IList<Symbol> pair) =>
            new() { Current = pair[0], Next = pair[1] };

        public static bool IsBreakAllowed(this SymbolsPair pair, IBreakRule[] rules)
        {
            var allowBreak = rules.Select(r => r.AllowBreak(pair.Current, pair.Next))
                                  .FirstOrDefault(r => r.HasValue);

            return !allowBreak.HasValue || allowBreak.Value;
        }
    }
}
