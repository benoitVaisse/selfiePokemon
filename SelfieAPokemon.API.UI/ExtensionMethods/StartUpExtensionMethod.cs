using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfieAPokemon.Core.Domain.Interfaces;
using SelfieAPokemon.Core.Infrastructures.Data;
using SelfieAPokemon.Core.Infrastructures.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAPokemon.API.UI.ExtensionMethods
{
    public static class StartUpExtensionMethod
    {

        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, SelfieRepository>();
            return services;
        }

        public static IServiceCollection SetDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<SelfiesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PokemonConnectionString"), sqlOption => {

                });
            });

            return services;
        }


    }
}
