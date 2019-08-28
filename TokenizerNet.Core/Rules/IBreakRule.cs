using TokenizerNet.Core.Domain;

namespace TokenizerNet.Core.Rules
{
    public interface IBreakRule
    {
        string UnicodeStandardId { get; }

        bool? AllowBreak(Symbol current, Symbol next);
    }
}
