using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SelfieAPokemon.Core.Application.Services;
using SelfieAPokemon.Core.Application.Services.Interfaces;
using SelfieAPokemon.Core.Domain;
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
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<ISelfieRepository, SelfieRepository>();
            services.AddScoped<IRegisterImageToServerService, RegisterImageToServerService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
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

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<User>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;

                options.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddEntityFrameworkStores<SelfiesContext>();
            return services;
        }

        /// <summary>
        /// Add Cors 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(config.GetSection("Security:CorsPolicy").Value, builder =>
                {
                    builder.WithOrigins("*")
                            .WithMethods("*")
                            .WithHeaders("*");
                });
            });
            return services;
        }

        public static IServiceCollection AddCustomJWT(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //claims enregistré
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Security:JwtToken"])),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,
                    // clef d'enregistrement
                };
                
            });


            return services;
        }


    }
}
