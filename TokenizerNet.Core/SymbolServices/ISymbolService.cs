using System.Collections.Generic;
using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.SymbolServices
{
    public interface ISymbolService
    {
        IEnumerable<Symbol> SplitToSymbols(string text, IList<Symbol> symbolLibrary);
    }
}
