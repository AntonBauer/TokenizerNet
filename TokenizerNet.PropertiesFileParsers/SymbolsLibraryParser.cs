using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TokenizerNet.Core.Domain;
using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.PropertiesFileParsers
{
    public static class SymbolsLibraryParser
    {
        private const string CommentLine = "#";

        public static IEnumerable<Symbol> Parse(string filePath)
        {
            foreach(var line in File.ReadAllLines(filePath).Where(IsDataLine))
            {
                var splitted = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rawSpan = splitted[0];
                var rawType = splitted[2];
                var name = string.Join(" ", splitted.Skip(5).Take(splitted.Length - 5));

                yield return new Symbol(ParseCodeSpan(rawSpan), ParseType(rawType), name);
            }
        }

        private static bool IsDataLine(string line) => !(string.IsNullOrEmpty(line) || line.StartsWith(CommentLine));

        private static CodeSpan ParseCodeSpan(string codeSpan)
        {
            var splitted = codeSpan.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted.Length == 2
                ? new CodeSpan(Convert.ToInt32(splitted[0], 16), Convert.ToInt32(splitted[1], 16))
                : new CodeSpan(Convert.ToInt32(splitted[0], 16));
        }

        private static SymbolType ParseType(string symbolType)
        {
            switch (symbolType)
            {
                case "Double_Quote":
                    return SymbolType.DoubleQuote;
                case "Single_Quote":
                    return SymbolType.SingleQuote;
                case "Hebrew_Letter":
                    return SymbolType.HebrewLetter;
                case "CR":
                    return SymbolType.CarriageReturn;
                case "LF":
                    return SymbolType.LineFinish;
                case "Newline":
                    return SymbolType.NewLine;
                case "Extend":
                    return SymbolType.Extend;
                case "Format":
                    return SymbolType.Format;
                case "Katakana":
                    return SymbolType.Katakana;
                case "ALetter":
                    return SymbolType.ALetter;
                case "MidLetter":
                    return SymbolType.MidLetter;
                case "MidNum":
                    return SymbolType.MidNum;
                case "MidNumLet":
                    return SymbolType.MidNumLet;
                case "Numeric":
                    return SymbolType.Numeric;
                case "ExtendNumLet":
                    return SymbolType.ExtendNumLet;
                case "ZWJ":
                    return SymbolType.ZWJ;
                case "WSegSpace":
                    return SymbolType.WSegSpace;
                default:
                    return SymbolType.Other;
            }
        }
    }
}
