﻿using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules.WordBoundariesRules
{
    public sealed class IgnoreFormatBreakingRule : IBreakRule
    {
        public string UnicodeStandardId => "WB4";

        public bool? AllowBreak(Symbol current, Symbol next) =>
            next.Type == SymbolType.Format || next.Type == SymbolType.Extend || next.Type == SymbolType.ZWJ ? false : default(bool?);
    }
}