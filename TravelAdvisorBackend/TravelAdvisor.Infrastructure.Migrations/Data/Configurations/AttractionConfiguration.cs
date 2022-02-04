using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Migrations.Data.Configurations
{
    public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired(false).HasMaxLength(50);
            //builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Details).IsRequired(false).HasMaxLength(1200);

            //builder.HasMany(x => x.Reviews).WithOne(x => x.Attraction); //.HasForeignKey(x => x.Attraction.Id); ???

            builder.ToTable("Attractions");
        }
    }
}
