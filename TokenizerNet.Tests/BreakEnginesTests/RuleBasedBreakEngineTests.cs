using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TokenizerNet.Core.BreakEngines;
using TokenizerNet.Core.BreakEngines.Factories;
using TokenizerNet.Core.Domain.Enums;
using TokenizerNet.Core.Rules.RulesFactories;
using TokenizerNet.Core.SymbolServices;

namespace TokenizerNet.Tests.BreakEnginesTests
{
    [TestFixture]
    [Category("Break engines")]
    public class RuleBasedBreakEngineTests
    {
        private IBreakEngine _engine;

        [OneTimeSetUp]
        public void Setup()
        {
            var symbolService = new SymbolService();
            var rulesFactory = new RulesFactory();
            var factory = new BreakEngineFactory(symbolService, rulesFactory.GetWordBreakRules());

            _engine = factory.CreateEngine(BreakType.Word);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void FindWordBoundariesTest(string text, string[] words)
        {
            // Arrange

            // Act
            var boundaries = _engine.FindBoundaries(text).ToArray();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(boundaries, Is.Not.Null, "words Array is empty");
                CollectionAssert.IsNotEmpty(boundaries, "Boundaries are empty");

                var actualWords = Break(text, boundaries);
                CollectionAssert.AreEquivalent(words, actualWords, "Wrong words breaking");
            });
        }

        public static IEnumerable<TestCaseData> TestCases()
        {
            var sentence = "The quick (\"brown\") fox can't jump 32.2 feet, right?";
            var words = new[] { "The", " ", "quick", "(", "\"", "brown", "\"", " ", "fox", " ", "can", "'", "t", " ", "jump", " ", "32.2", " ", "feet", ",", " ", "right", "?"};
            yield return new TestCaseData(sentence, words).SetName("Brown fox");
        }

        private static List<string> Break(string text, int[] breakIndexes)
        {
            var words = new List<string>();
            var lastIndex = 0;
            foreach (var index in breakIndexes)
            {
                var length = index - lastIndex;

                var word = text.Substring(lastIndex, length);
                words.Add(word);

                lastIndex = index;
            }

            var lastWord = text.Substring(lastIndex);
            words.Add(lastWord);

            return words;
        }
    }
}
