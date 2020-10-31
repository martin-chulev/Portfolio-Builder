using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PortfolioBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Data
{
    public class PortfolioDbContext : DbContext
    {
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectSubskill> ProjectSkills { get; set; }

        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stringListValueComparer = new ValueComparer<List<string>>(
                                           (v1, v2) => string.Join("|", v1).Equals(string.Join("|", v2)),
                                           v => v.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                                           v => v.ToList());

            modelBuilder.Entity<Resource>()
                        .Property(r => r.URLs)
                        .HasConversion(
                            v => string.Join("|", v),
                            v => v.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList())
                        .Metadata.SetValueComparer(stringListValueComparer);

            modelBuilder.Entity<Project>()
                        .Property(p => p.Geolocations)
                        .HasConversion(
                            v => string.Join("|", v),
                            v => v.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList())
                        .Metadata.SetValueComparer(stringListValueComparer);

            modelBuilder.Entity<ProjectSubskill>()
                .HasKey(ps => new { ps.ProjectId, ps.SubskillId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
