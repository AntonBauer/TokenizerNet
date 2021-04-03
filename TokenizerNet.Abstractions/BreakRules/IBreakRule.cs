using TokenizerNet.Core;

namespace TokenizerNet.Abstractions.BreakRules
{
    public interface IBreakRule
    {
        string UnicodeStandardId { get; }

        bool? AllowBreak(Symbol current, Symbol next);
    }
}
