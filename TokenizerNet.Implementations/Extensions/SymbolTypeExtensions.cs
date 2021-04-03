using TokenizerNet.Core.Enums;

namespace TokenizerNet.Implementations.Extensions
{
    internal static class SymbolTypeExtensions
    {
        public static bool IsNewLine(this SymbolType type) =>
            type == SymbolType.CarriageReturn
            || type == SymbolType.LineFinish
            || type == SymbolType.NewLine;
    }
}
