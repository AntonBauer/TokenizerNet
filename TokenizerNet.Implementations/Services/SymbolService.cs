using System.Collections.Generic;
using TokenizerNet.Abstractions.SymbolServices;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.Services
{
    public sealed class SymbolService : ISymbolService
    {
        public IList<Symbol> LoadSymbolLibrary(BreakType breakType) => throw new System.NotImplementedException();
        public IEnumerable<Symbol> SplitToSymbols(string text, Symbol[] symbolLibrary) => throw new System.NotImplementedException();
    }
}
