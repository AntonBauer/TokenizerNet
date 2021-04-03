using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Abstractions.BreakEngines;
using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Abstractions.SymbolServices;
using TokenizerNet.Core;
using TokenizerNet.Implementations.Extensions;

namespace TokenizerNet.Implementations.Services
{
    public sealed class RuleBasedBreakEngine : IBreakEngine
    {
        private readonly IBreakRule[] _rules;
        private readonly Symbol[] _symbolsLibrary;
        private readonly ISymbolService _symbolService;

        public RuleBasedBreakEngine(
            IBreakRule[] rules,
            ISymbolService symbolService,
            IEnumerable<Symbol> symbolsLibrary
        )
        {
            _rules = rules;
            _symbolService = symbolService;
            _symbolsLibrary = symbolsLibrary.ToArray();
        }

        public IEnumerable<int> FindBoundaries(string text)
        {
            var textSymbols = _symbolService.SplitToSymbols(text, _symbolsLibrary);
            var currentIndex = 1;

            foreach(var isAllowed in textSymbols.Window(2)
                                                .Select(window => window.ToSymbolPair())
                                                .Select(pair => pair.IsBreakAllowed(_rules)))
            {
                if (isAllowed)
                    yield return currentIndex;
                ++currentIndex;
            }
        }
    }
}
