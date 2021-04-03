using System.Collections.Generic;
using System.Linq;
using System.Text;
using TokenizerNet.Core;

namespace TokenizerNet.Abstractions.SymbolServices
{
    public interface ISymbolService
    {
        IEnumerable<Symbol> SplitToSymbols(string text, Symbol[] symbolLibrary) =>
            string.IsNullOrEmpty(text)
                ? Enumerable.Empty<Symbol>()
                : Encoding.UTF8.GetBytes(text)
                               .Select(b => b.AsSpan().ToSymbol(symbolLibrary));
    }
}
