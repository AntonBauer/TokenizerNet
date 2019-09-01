using System.Collections.Generic;
using System.Linq;

namespace TokenizerNet.Core.Rules.RulesFactories
{
    public sealed class RulesFactory : IRulesFactory
    {
        public IEnumerable<IBreakRule> GetWordBreakRules(string language)
        {
            return Enumerable.Empty<IBreakRule>();
        }
    }
}
