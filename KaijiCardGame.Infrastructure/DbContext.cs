using KaijiCardGame.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaijiCardGame.Infrastructure
{
    public class DbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(m => Console.WriteLine(m))
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Players)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasKey(c => new { c.ZipCode });

            modelBuilder.Entity<Game>()
                .HasKey(g => new { g.PlayerOneId, g.PlayerTwoId, g.DateStarted });

            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerOne)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PlayerOneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerTwo)
                .WithMany().HasForeignKey(g => g.PlayerTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(e => e.User)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }

    }
}
