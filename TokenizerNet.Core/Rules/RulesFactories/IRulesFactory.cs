using System.Collections.Generic;

namespace TokenizerNet.Core.Rules.RulesFactories
{
    public interface IRulesFactory
    {
        IEnumerable<IBreakRule> GetWordBreakRules(string language);
    }
}
