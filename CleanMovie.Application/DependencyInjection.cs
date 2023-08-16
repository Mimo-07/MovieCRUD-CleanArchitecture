using CleanMovie.Application.IServices;
using CleanMovie.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }
    }
}
