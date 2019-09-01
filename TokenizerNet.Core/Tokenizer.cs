using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Rules;
using TokenizerNet.Core.SymbolServices;

namespace TokenizerNet.Core
{
    public class Tokenizer
    {
        private readonly List<IBreakRule> _rules;
        private readonly List<Symbol> _symbolsLibrary;
        private readonly ISymbolService _symbolService;

        public Tokenizer(ISymbolService symbolService, IEnumerable<Symbol> symbolsLibrary, IEnumerable<IBreakRule> rules)
        {
            _symbolService = symbolService;
            _rules = rules.ToList();
            _symbolsLibrary = symbolsLibrary.ToList();
        }

        public IEnumerable<int> FindWirdBoundaries(string text)
        {
            var textSymbols = _symbolService.SplitToSymbols(text, _symbolsLibrary);
            return FindBreaks(textSymbols);
        }

        private IEnumerable<int> FindBreaks(IEnumerable<Symbol> symbols)
        {
            var index = 1;

            foreach (var pair in symbols.Window(2))
            {
                var allowBreak = _rules.Select(r => r.AllowBreak(pair[0], pair[1])).FirstOrDefault(r => r.HasValue);

                if (allowBreak.HasValue && allowBreak.Value)
                    yield return index;

                ++index;
            }
        }
    }
}
