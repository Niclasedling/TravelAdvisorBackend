using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Data.Configurations;
using TravelAdvisor.Infrastructure.Migrations.Data.Seeding;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Migrations.Data
{
    public class DbApplicationContext: DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ThumbInteraction> ThumbInteractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUsers();
            modelBuilder.SeedAttraction();

            // felsök error = Object reference not set to an instance of an object.
            //modelBuilder.SeedReview();

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
