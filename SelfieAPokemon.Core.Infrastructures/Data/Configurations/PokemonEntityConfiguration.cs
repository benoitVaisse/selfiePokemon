using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAPokemon.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Infrastructures.Data.Configurations
{
    class PokemonEntityConfiguration : IEntityTypeConfiguration<Pokemon>
    {

        #region MyRegion

        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemon");
        }
        #endregion
    }
}
