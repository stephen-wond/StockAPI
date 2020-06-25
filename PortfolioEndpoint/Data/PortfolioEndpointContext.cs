using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models;

namespace PortfolioEndpoint.Data
{
    public class PortfolioEndpointContext : DbContext
    {
        public PortfolioEndpointContext(DbContextOptions<PortfolioEndpointContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, FirstName = "Carson" },
                new User() { UserId = 2, FirstName = "Meredith" },
                new User() { UserId = 3, FirstName = "Arturo" });

            modelBuilder.Entity<Stock>().HasData(
                new Stock() { StockId = 1, UserId = 1, SymbolId = 1, InitialPrice = 1234, TargetPrice = 1235, LastAlertPrice = 1234, IsActive = true },
                new Stock() { StockId = 2, UserId = 1, SymbolId = 2, InitialPrice = 1234, TargetPrice = 1235, LastAlertPrice = 1234, IsActive = true },
                new Stock() { StockId = 3, UserId = 2, SymbolId = 1, InitialPrice = 4321, TargetPrice = 4322, LastAlertPrice = 4321, IsActive = true });
        }
    }
}
