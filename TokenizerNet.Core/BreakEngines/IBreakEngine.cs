using System.Collections.Generic;

namespace TokenizerNet.Core.BreakEngines
{
    public interface IBreakEngine
    {
        IEnumerable<int> FindBoundaries(string text);
    }
}
