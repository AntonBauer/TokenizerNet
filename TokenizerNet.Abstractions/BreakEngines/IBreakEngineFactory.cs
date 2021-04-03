using TokenizerNet.Core.Enums;

namespace TokenizerNet.Abstractions.BreakEngines
{
    public interface IBreakEngineFactory
    {
        IBreakEngine CreateEngine(BreakType breakType);
    }
}
