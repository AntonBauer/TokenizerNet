using System.Collections.Generic;
using TokenizerNet.Core;
using TokenizerNet.Core.Rules.RulesFactories;
using TokenizerNet.Core.SymbolServices;
using TokenizerNet.PropertiesFileParsers;

namespace TokenizerNet.App
{
    class Program
    {
        static void Main()
        {
            var exampleSentence = "The quick (\"brown\") fox can't jump 32.2 feet, right?";

            var symbolsLibrary = new SymbolsLibraryParser().Parse(@"c:\Development\Personal\TokenizerNet\Data\WordBreakProperty.txt");
            var symbolService = new SymbolService();
            var rules = new RulesFactory().GetWordBreakRules();

            var tokenizer = new Tokenizer(symbolService, symbolsLibrary, rules);
            var breakIndexes = tokenizer.FindBoundaries(exampleSentence);

            var words = new List<string>();
            var lastIndex = 0;
            foreach(var index in breakIndexes)
            {
                var length = index - lastIndex;

                var word = exampleSentence.Substring(lastIndex, length); 
                words.Add(word);

                lastIndex = index;
            }

            var lastWord = exampleSentence.Substring(lastIndex);
            words.Add(lastWord);
        }
    }
}
