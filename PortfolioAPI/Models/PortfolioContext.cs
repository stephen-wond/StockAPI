using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAPI.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "Carson", LastName = "Alexander", LastContact = DateTime.Now },
                new User() { Id = 2, FirstName = "Meredith", LastName = "Alonso", LastContact = DateTime.Now },
                new User() { Id = 3, FirstName = "Arturo", LastName = "Anand", LastContact = DateTime.Now });

            modelBuilder.Entity<Symbol>().HasData(
                new Symbol() { Id = 1, Ticker = "TSLA", Name = "Tesla" },
                new Symbol() { Id = 2, Ticker = "PAY.L", Name = "PayPoint PLC" });

            modelBuilder.Entity<Stock>().HasData(
                new Stock() { Id = 1, UserId = 1, SymbolId = 1, InitialPrice = 1234, TargetPrice = 1235, ChangeAlert = 5, LastAlertPrice = 1234, IsActive = true },
                new Stock() { Id = 2, UserId = 1, SymbolId = 2, InitialPrice = 1234, TargetPrice = 1235, ChangeAlert = 5, LastAlertPrice = 1234, IsActive = true },
                new Stock() { Id = 3, UserId = 2, SymbolId = 1, InitialPrice = 4321, TargetPrice = 4322, ChangeAlert = 1, LastAlertPrice = 4321, IsActive = true });
        }
    }
}
