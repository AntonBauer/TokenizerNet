using System.Collections.Generic;

namespace TokenizerNet.Abstractions.BreakRules
{
    public interface IBreakRulesFactory
    {
        IEnumerable<IBreakRule> GetWordBreakRules();
    }
}
