using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TokenizerNet.Core.Domain;

namespace TokenizerNet.PropertiesFileParsers
{
    public class PropertiesParser
    {
        private const string CommentLine = "#";

        public IEnumerable<Symbol> Parse(string filePath)
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

            var startBytes = splitted[0].ConvertToByteArray();
            var endBytes = splitted.Length == 2 ? splitted[1].ConvertToByteArray() : startBytes;

            return new CodeSpan(startBytes, endBytes);
        }

        private static SymbolType ParseType(string symbolType)
        {
            switch (symbolType)
            {
                case "Double_Quote":
                    return SymbolType.Double_Quote;
                case "Single_Quote":
                    return SymbolType.Single_Quote;
                case "Hebrew_Letter":
                    return SymbolType.Hebrew_Letter;
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
