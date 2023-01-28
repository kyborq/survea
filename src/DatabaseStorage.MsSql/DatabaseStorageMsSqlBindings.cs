using Core.UnitOfWork;
using DatabaseStorage.Abstractions.Repositories;
using DatabaseStorage.MsSql.Repositories;
using DatabaseStorage.MsSql.UnitOfWorkImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseStorage.MsSql
{
    public static class DatabaseStorageMsSqlBindings
    {
        public static void AddMsSqlDatabaseStorage( this IServiceCollection services )
        {
            //services.AddScoped<IDbContext, ApplicationContext>();
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IUnitOfWork, MsSqlUnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDetailedUserInfoRepository, DetailedUserInfoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
