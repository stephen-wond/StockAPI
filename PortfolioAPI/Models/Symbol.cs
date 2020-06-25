using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortfolioAPI.Models
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
