using System.Threading.Tasks;

namespace TokenizerNet.Abstractions.SymbolServices
{
    public interface ISymbolsLibraryProvider
    {
        public Task<string> LoadLibraryContentAsync();
    }
}
