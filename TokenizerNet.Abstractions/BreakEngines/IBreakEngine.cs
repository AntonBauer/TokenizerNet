using System.Collections.Generic;

namespace TokenizerNet.Abstractions.BreakEngines
{
    public interface IBreakEngine
    {
        IEnumerable<int> FindBoundaries(string text);
    }
}
