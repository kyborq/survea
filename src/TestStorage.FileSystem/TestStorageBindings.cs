using Microsoft.Extensions.DependencyInjection;
using TestStorage.Abstractions;

namespace TestStorage.FileSystem
{
    public static class TestStorageBindings
    {
        public static void AddTestStorage( this IServiceCollection services )
        {
            services.AddScoped<ITestStorage, TestStorage>();
        }
    }
}
