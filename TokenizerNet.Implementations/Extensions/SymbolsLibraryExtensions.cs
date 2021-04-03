using System;
using System.Linq;
using TokenizerNet.Core;
using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.Extensions
{
    internal static class SymbolsLibraryExtensions
    {
        private const string CommentLine = "#";

        public static Symbol ToSymbol(this string line)
        {
            var splitted = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new()
            {
                Span = splitted[0].ToCodeSpan(),
                Type = splitted[2].ToSymbolType(),
                Name = string.Join(" ", splitted.Skip(5).Take(splitted.Length - 5))
            };
        }

        public static bool IsDataLine(this string line) =>
            !(string.IsNullOrEmpty(line) || line.StartsWith(CommentLine));

        public static CodeSpan ToCodeSpan(this string codeSpan)
        {
            var splitted = codeSpan.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted.Length == 2
                ? new() { Start = Convert.ToInt32(splitted[0], 16), End = Convert.ToInt32(splitted[1], 16) }
                : Convert.ToInt32(splitted[0], 16).AsSpan();
        }

        public static SymbolType ToSymbolType(this string symbolType) =>
            symbolType switch
            {
                "Double_Quote" => SymbolType.DoubleQuote,
                "Single_Quote" => SymbolType.SingleQuote,
                "Hebrew_Letter" => SymbolType.HebrewLetter,
                "CR" => SymbolType.CarriageReturn,
                "LF" => SymbolType.LineFinish,
                "Newline" => SymbolType.NewLine,
                "Extend" => SymbolType.Extend,
                "Format" => SymbolType.Format,
                "Katakana" => SymbolType.Katakana,
                "ALetter" => SymbolType.ALetter,
                "MidLetter" => SymbolType.MidLetter,
                "MidNum" => SymbolType.MidNum,
                "MidNumLet" => SymbolType.MidNumLet,
                "Numeric" => SymbolType.Numeric,
                "ExtendNumLet" => SymbolType.ExtendNumLet,
                "ZWJ" => SymbolType.ZWJ,
                "WSegSpace" => SymbolType.WSegSpace,
                _ => SymbolType.Other,
            };
    }
}
