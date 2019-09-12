using TokenizerNet.Core.Domain.Enums;

namespace TokenizerNet.Core.BreakEngines.Factories
{
    public interface IBreakEngineFactory
    {
        IBreakEngine CreateEngine(BreakType breakType);
    }
}
