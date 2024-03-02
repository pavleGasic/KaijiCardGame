using KaijiCardGame.Domain;
using Microsoft.EntityFrameworkCore;

namespace KaijiCardGame.Infrastructure
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.LogTo(m => Console.WriteLine(m))
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(c => new { c.ZipCode });
            modelBuilder.Entity<Game>().HasKey(g => new { g.PlayerOneId, g.PlayerTwoId, g.DateStarted });
            modelBuilder.Entity<Game>().HasOne(g => g.PlayerOne).WithMany(p => p.Games).HasForeignKey(g => g.PlayerOneId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>().HasOne(g => g.PlayerTwo).WithMany().HasForeignKey(g => g.PlayerTwoId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}