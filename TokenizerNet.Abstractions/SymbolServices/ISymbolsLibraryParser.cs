using System.Collections.Generic;
using TokenizerNet.Core;

namespace TokenizerNet.Abstractions.SymbolServices
{
    public interface ISymbolsLibraryParser
    {
        public IEnumerable<Symbol> ParseLibrary(string libraryContent);
    }
}
