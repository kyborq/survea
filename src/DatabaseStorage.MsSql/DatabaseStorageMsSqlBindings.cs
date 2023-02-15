using DatabaseStorage.Abstractions.Repositories;
using DatabaseStorage.MsSql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseStorage.MsSql
{
    public static class DatabaseStorageMsSqlBindings
    {
        public static void AddMsSqlDatabaseStorage( this IServiceCollection services )
        {
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDetailedUserInfoRepository, DetailedUserInfoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IAttemptRepository, AttemptRepository>();
        }
    }
}
