using Microsoft.Extensions.DependencyInjection;
using TokenizerNet.Abstractions.BreakEngines;
using TokenizerNet.Abstractions.BreakRules;
using TokenizerNet.Abstractions.SymbolServices;
using TokenizerNet.Implementations.Services;

namespace TokenizerNet.Implementations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTokenizerNet(this IServiceCollection services) =>
            services.AddTransient<IBreakRulesFactory, BreakRulesFactory>()
                    .AddTransient<ISymbolsLibraryParser, SymbolsLibraryParser>()
                    .AddTransient<IBreakEngine, RuleBasedBreakEngine>()
                    .AddTransient<ISymbolService, SymbolService>();
    }
}
