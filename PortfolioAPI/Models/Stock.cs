using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortfolioAPI.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SymbolId { get; set; }
        public double InitialPrice { get; set; }
        public double? TargetPrice { get; set; }
        public int ChangeAlert { get; set; }
        public double LastAlertPrice { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public Symbol Symbol { get; set; }
    }
}
