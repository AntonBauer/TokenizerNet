using System.Collections.Generic;
using TokenizerNet.Core.Rules.WordBoundariesRules;

namespace TokenizerNet.Core.Rules.RulesFactories
{
    public sealed class RulesFactory : IRulesFactory
    {
        public IEnumerable<IBreakRule> GetWordBreakRules()
        {
            //yield return new StartTextBreakRule();
            //yield return new EndTextBreakRule();
            yield return new NewLineBreakRule();
            yield return new HorizontalSpaceBreakRule();
            yield return new IgnoreFormatBreakingRule();
            yield return new BetweenLettersBreakingRule();

            yield return new FallbackBreakRule();
        }
    }
}
