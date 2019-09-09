using System.Collections.Generic;
using System.Linq;

namespace TokenizerNet.Core.BreakEngines
{
    public sealed class CjkBreakEngine : IBreakEngine
    {
        public IEnumerable<int> FindBoundaries(string text) => Enumerable.Empty<int>();
    }
}
