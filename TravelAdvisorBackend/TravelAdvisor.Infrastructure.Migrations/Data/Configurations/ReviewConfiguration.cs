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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Rating).IsRequired();

            builder.HasOne(x => x.User); // ???
            builder.Property(x => x.User).IsRequired();

            //builder.HasOne(x => x.Attraction).WithMany(x => x.Reviews)
            //        .HasForeignKey(x => x.Attraction.Id)
            //        .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Attraction);

            builder.ToTable("Reviews");
        }
    }
}
