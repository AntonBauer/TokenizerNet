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

        public void TokenizeWords(string text)
        {
            var textSymbols = _symbolService.SplitToSymbols(text, _symbolsLibrary);
            var breaks = FindBreaks(textSymbols).ToList();
        }

        private IEnumerable<int> FindBreaks(IEnumerable<Symbol> symbols)
        {
            var pairedSymbols = symbols.Window(2).ToList();

            var pairsIndexes = new List<int>();
            for (var i = 0; i < pairedSymbols.Count; i++)
            {
                var pair = pairedSymbols[i];
                foreach (var rule in _rules)
                {
                    var allowBreak = rule.AllowBreak(pair[0], pair[1]) ?? false;
                    if (allowBreak)
                    {
                        pairsIndexes.Add(i);
                        break;
                    }
                }
            }

            return Enumerable.Empty<int>();
        }
    }
}
