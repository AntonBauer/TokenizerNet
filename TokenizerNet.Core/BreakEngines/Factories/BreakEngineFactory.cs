using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.Domain.Enums;
using TokenizerNet.Core.Rules;
using TokenizerNet.Core.SymbolServices;

namespace TokenizerNet.Core.BreakEngines.Factories
{
    public sealed class BreakEngineFactory : IBreakEngineFactory
    {
        private readonly IBreakRule[] _breakRules;
        private readonly ISymbolService _symbolService;

        public BreakEngineFactory(ISymbolService symbolService, IEnumerable<IBreakRule> breakRules)
        {
            _symbolService = symbolService;
            _breakRules = breakRules.ToArray();
        }

        public IBreakEngine CreateEngine(BreakType breakType)
        {
            var symbolsLibrary = _symbolService.LoadSymbolLibrary(breakType);
            return new RuleBasedBreakEngine(_symbolService, symbolsLibrary, _breakRules);
        }
    }
}
