using Microsoft.EntityFrameworkCore;
using Roulette.Models;
using System;

#nullable disable

namespace Roulette
{
    public partial class RouletteContext : DbContext
    {
        public RouletteContext()
        {
        }

        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Tier> Tiers { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource=G:\\efimov\\Projects\\Roulette_2\\Roulette_2\\Roulette_4.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tier>(entity =>
            {
                entity.ToTable("Tier");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");

                entity.HasIndex(e => e.TierId, "IX_Titles_TierId");

                entity.HasOne(d => d.Tier)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.TierId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
