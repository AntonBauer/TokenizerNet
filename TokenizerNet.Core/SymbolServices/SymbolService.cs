using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.SymbolServices
{
    public sealed class SymbolService : ISymbolService
    {
        public IEnumerable<Symbol> SplitToSymbols(string text, IList<Symbol> symbolLibrary) =>
            string.IsNullOrEmpty(text)
                ? Enumerable.Empty<Symbol>()
                : Encoding.UTF8.GetBytes(text).Select(b => CreateSymbol(new CodeSpan(new[] { b }), symbolLibrary));

        private Symbol CreateSymbol(CodeSpan span, IList<Symbol> symbolsLibrary)
        {
            var libSymbol = symbolsLibrary.FirstOrDefault(s => s.Span.Contains(span));
            return libSymbol.Equals(default(Symbol))
                ? new Symbol(span)
                : new Symbol(span, libSymbol.Type, libSymbol.Name);
        }
    }
}
