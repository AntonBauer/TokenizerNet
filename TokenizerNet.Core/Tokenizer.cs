using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Rules;

namespace TokenizerNet.Core
{
    public class Tokenizer
    {
        private readonly List<IBreakRule> _rules;

        public Tokenizer(IEnumerable<IBreakRule> rules)
        {
            _rules = rules.ToList();
        }

        public void TokenizeWords(string text)
        {
            var textSymbols = SplitToSymbols(text);
        }

        private List<Symbol> SplitToSymbols(string text)
        {
            var start = new Symbol(SymbolType.StartOfText);
            var end = new Symbol(SymbolType.EndOfText);

            return new List<Symbol> { start, end };
        }
    }
}
