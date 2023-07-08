using Microsoft.EntityFrameworkCore;
using TicTacToeOnline.Models;

namespace TicTacToeOnline.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}
