namespace TokenizerNet.Core.Domain
{
    public enum SymbolType
    {
        Other,
        StartOfText,
        EndOfText,
        CarriageReturn,
        LineFinish,
        WSegSpace,
        Extend,
        DoubleQuote,
        SingleQuote,
        HebrewLetter,
        Format,
        Katakana,
        ALetter,
        MidLetter,
        MidNum,
        MidNumLet,
        Numeric,
        ExtendNumLet,
        ZWJ,
        NewLine
    }
}
