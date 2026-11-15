using EventHub.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventHub
{
    internal class EventHubDbContext : DbContext
    {
        public EventHubDbContext() : base()
        {
        }
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Badge> Badges => Set<Badge>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EventHubDb;Trusted_Connection=True; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizerProfile>(builder =>
            {
                builder.HasKey(op => op.Id);
                builder.Property(op => op.Bio).IsRequired().HasMaxLength(1000);

                builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
