using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.SymbolServices;

namespace TokenizerNet.Core.BreakEngines
{
    public sealed class CjkBreakEngine : IBreakEngine
    {
        private readonly ISymbolService _symbolService;
        private readonly List<Symbol> _symbolLibrary;

        public CjkBreakEngine(ISymbolService symbolService, IEnumerable<Symbol> symbolLibrary)
        {
            _symbolService = symbolService;
            _symbolLibrary = symbolLibrary.ToList();
        }

        public IEnumerable<int> FindBoundaries(string text)
        {
            var symbols = _symbolService.SplitToSymbols(text, _symbolLibrary);
            return Enumerable.Empty<int>();
        }
    }
}
