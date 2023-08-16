using CleanMovie.Domain.Interfaces;
using CleanMovie.Infrastructure.Data;
using CleanMovie.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMovie.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(MovieDbContext).Assembly.FullName)),ServiceLifetime.Transient);

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
