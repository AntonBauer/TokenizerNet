﻿using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Rules;
using TokenizerNet.Core.SymbolServices;

namespace TokenizerNet.Core.BreakEngines
{
    public sealed class RuleBasedBreakEngine : IBreakEngine
    {
        private readonly List<IBreakRule> _rules;
        private readonly List<Symbol> _referenceSymbolsLibrary;
        private readonly ISymbolService _symbolService;

        public RuleBasedBreakEngine(ISymbolService symbolService, IEnumerable<Symbol> referenceSymbolsLibrary, IEnumerable<IBreakRule> rules)
        {
            _symbolService = symbolService;
            _rules = rules.ToList();
            _referenceSymbolsLibrary = referenceSymbolsLibrary.ToList();
        }

        public IEnumerable<int> FindBoundaries(string text)
        {
            var textSymbols = _symbolService.SplitToSymbols(text, _referenceSymbolsLibrary);
            return FindBreaks(textSymbols);
        }

        private IEnumerable<int> FindBreaks(IEnumerable<Symbol> symbols)
        {
            var index = 1;

            foreach (var pair in symbols.Window(2))
            {
                var allowBreak = _rules.Select(r => r.AllowBreak(pair[0], pair[1])).FirstOrDefault(r => r.HasValue);

                if (!allowBreak.HasValue || allowBreak.Value)
                    yield return index;

                ++index;
            }
        }
    }
}