using EventHub.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b=> b.Id);
            builder.Property(b => b.BadgeNumber).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Tier).IsRequired().HasConversion<string>();

            builder.HasOne(b => b.Attendee)
               .WithOne(a => a.Badge)
               .HasForeignKey<Badge>(b => b.AttendeeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
