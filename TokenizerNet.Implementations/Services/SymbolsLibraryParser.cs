using System;
using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Abstractions.SymbolServices;
using TokenizerNet.Core;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.Services
{
    public sealed class SymbolsLibraryParser : ISymbolsLibraryParser
    {
        public IEnumerable<Symbol> ParseLibrary(string libraryContent) =>
            libraryContent.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                          .Where(l => l.IsDataLine())
                          .Select(l => l.ToSymbol());
    }
}
