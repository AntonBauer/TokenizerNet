namespace TokenizerNet.Core.Domain
{
    public enum SymbolType
    {
        Other,

        StartOfText,
        EndOfText,

        CarriageReturn,
        LineFinish,
        NewLine,

        WSegSpace,
        Extend,
        Double_Quote,
        Single_Quote,
        Hebrew_Letter,
        Format,
        Katakana,
        ALetter,
        MidLetter,
        MidNum,
        MidNumLet,
        Numeric,
        ExtendNumLet,
        ZWJ
    }
}
