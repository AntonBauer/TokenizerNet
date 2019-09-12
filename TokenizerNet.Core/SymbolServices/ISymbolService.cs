using System.Collections.Generic;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.SymbolServices
{
    public interface ISymbolService
    {
        IList<Symbol> LoadSymbolLibrary(BreakType breakType);

        IEnumerable<Symbol> SplitToSymbols(string text, IList<Symbol> symbolLibrary);
    }
}
