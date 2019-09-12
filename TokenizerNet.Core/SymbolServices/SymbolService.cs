using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;
using TokenizerNet.Core.Properties;
using TokenizerNet.Core.Utils;

namespace TokenizerNet.Core.SymbolServices
{
    public sealed class SymbolService : ISymbolService
    {
        public IList<Symbol> LoadSymbolLibrary(BreakType breakType)
        {
            var libraryFilePath = GetLibraryFileContent(breakType);
            return SymbolsLibraryParser.ParseContent(libraryFilePath).ToList();
        }

        public IEnumerable<Symbol> SplitToSymbols(string text, IList<Symbol> symbolLibrary) =>
            string.IsNullOrEmpty(text)
                ? Enumerable.Empty<Symbol>()
                : Encoding.UTF8.GetBytes(text).Select(b => CreateSymbol(new CodeSpan(Convert.ToInt32(b)), symbolLibrary));

        private Symbol CreateSymbol(CodeSpan span, IList<Symbol> symbolsLibrary)
        {
            var libSymbol = symbolsLibrary.FirstOrDefault(s => s.Span.Contains(span));
            return libSymbol.Equals(default(Symbol))
                ? new Symbol(span)
                : new Symbol(span, libSymbol.Type, libSymbol.Name);
        }

        private string GetLibraryFileContent(BreakType breakType)
        {
            switch (breakType)
            {
                case BreakType.Word:
                    return Resources.WordBreakProperty;

                case BreakType.Sentence:
                    return Resources.SentenceBreakProperty;

                default:
                    throw new ArgumentException($"Unknown break type: {breakType}", nameof(breakType));
            }
        }
    }
}
