using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EhailingWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EhailingWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Status>()
                .HasMany(s => s.Users)
                .WithOne(u => u.Status)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            builder.Entity<Platform>()
                .HasMany(p => p.Users)
                .WithOne(u => u.Platform)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            builder.Entity<Region>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Region)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        
    }
}
