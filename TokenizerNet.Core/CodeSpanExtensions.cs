using System;
using System.Linq;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Core
{
    public static class CodeSpanExtensions
    {
        public static Symbol ToSymbol(this CodeSpan span) =>
            new() { Name = "Other", Span = span, Type = SymbolType.Other };

        public static Symbol ToSymbol(this CodeSpan span, Symbol[] library)
        {
            var libSymbol = library.FirstOrDefault(s => s.Span.Contains(span));
            return libSymbol == default
                ? span.ToSymbol()
                : libSymbol with { Span = span };
        }

        public static bool Contains(this CodeSpan original, CodeSpan other) =>
            original.Start <= other.Start && other.End <= original.End;

        public static CodeSpan AsSpan(this int singlePosition) =>
            new() { Start = singlePosition, End = singlePosition };

        public static CodeSpan AsSpan(this byte @byte) =>
            Convert.ToInt32(@byte).AsSpan();
    }
}
