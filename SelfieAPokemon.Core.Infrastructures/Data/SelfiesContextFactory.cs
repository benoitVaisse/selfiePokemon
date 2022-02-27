using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Infrastructures.Data
{
    class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
    {
        public SelfiesContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../SelfieAPokemon.API.UI/appsettings.json").Build();

            DbContextOptionsBuilder OptionBuilder = new DbContextOptionsBuilder<SelfiesContext>();
            OptionBuilder.UseSqlServer(configuration.GetConnectionString("PokemonConnectionString"));

            return new SelfiesContext(OptionBuilder.Options);
        }
    }
}
