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
    class SelfieEntityConfiguration : IEntityTypeConfiguration<Selfie>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");

            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.HasOne(s => s.Pokemon)
                    .WithMany(p => p.Selfies).OnDelete(DeleteBehavior.NoAction);

        }

        #endregion
    }
}
