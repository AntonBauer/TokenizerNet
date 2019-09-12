using System.Collections.Generic;
using TokenizerNet.Core.Rules.WordBoundariesRules;

namespace TokenizerNet.Core.Rules.RulesFactories
{
    public sealed class RulesFactory : IRulesFactory
    {
        public IEnumerable<IBreakRule> GetWordBreakRules()
        {
            // ToDo: add WB3c, WB15, WB16 rules

            yield return new NewLineBreakRule();
            yield return new HorizontalSpaceBreakRule();
            yield return new IgnoreFormatBreakingRule();
            yield return new BetweenLettersBreakingRule();
            yield return new AcrossPunctuationsBreakRule();
            yield return new NumericBreakRule();
            yield return new LetterNumberBreakRule();
            yield return new NumberLetterBreakRule();
            yield return new NumericSequencesBreakRule();
            yield return new KatakanaBreakRule();
            yield return new ExtendersBreakRule();
        }
    }
}
