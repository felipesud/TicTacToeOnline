using Microsoft.EntityFrameworkCore;
using TicTacToeOnline.Models;
using TicTacToeOnline.Data;

namespace TicTacToeOnline.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Board)
                .HasConversion(new CharArrayToStringConverter());

            base.OnModelCreating(modelBuilder);
        }
    }
}
