using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.SymbolServices
{
    public sealed class SymbolService : ISymbolService
    {
        public IEnumerable<Symbol> SplitToSymbols(string text, IList<Symbol> symbolLibrary)
        {
            yield return Symbol.StartOfText;

            if (string.IsNullOrEmpty(text))
            {
                yield return Symbol.EndOfText;
                yield break;
            }

            foreach (var pair in Encoding.UTF8.GetBytes(text).Window(2))
                yield return CreateSymbol(new CodeSpan(pair.ToArray()), symbolLibrary);

            yield return Symbol.EndOfText;
        }

        private Symbol CreateSymbol(CodeSpan span, IList<Symbol> symbolsLibrary)
        {
            var libSymbol = symbolsLibrary.FirstOrDefault(s => s.Span.Contains(span));
            return libSymbol.Equals(default(Symbol))
                ? new Symbol(span)
                : new Symbol(span, libSymbol.Type, libSymbol.Name);
        }
    }
}
