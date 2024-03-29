using DatabaseStorage.MsSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using TestStorage.FileSystem;

namespace Web.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext<ApplicationContext>( options =>
                     options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) ) );
            services.AddMsSqlDatabaseStorage();
            services.AddTestStorage();

            services.AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme )
                .AddCookie( o =>
                {
                    o.Events.OnRedirectToAccessDenied = context => 
                    {
                        context.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    };
                    o.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                } );
            services.AddAuthorization();
    
            services.AddControllers();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new OpenApiInfo { Title = "Web.Api", Version = "v1" } );
            } );
        }
        
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Web.Api v1" ) );
            }

            app.UseCors( builder => builder.WithOrigins("http://localhost:8080").AllowAnyHeader()
                .WithMethods( "GET", "POST", "PUT", "DELETE" ).AllowCredentials() );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllers();
            } );
        }
    }
}
