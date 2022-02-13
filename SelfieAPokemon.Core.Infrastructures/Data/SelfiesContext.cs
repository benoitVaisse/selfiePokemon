using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Infrastructures.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Infrastructures.Data
{
    public class SelfiesContext: DbContext
    {
        public SelfiesContext(DbContextOptions options):base(options)
        {

        }
        #region inernal Methode
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new SelfieEntityConfiguration());
        }
        #endregion

        #region properties
        public DbSet<Selfie> Selfie { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        #endregion
    }
}
