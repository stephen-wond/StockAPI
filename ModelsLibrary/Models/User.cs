using System;
using System.Collections.Generic;

namespace ModelsLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int ExternalId { get; set; }
        public string FirstName { get; set; }
        public DateTime LastContact { get; set; } = DateTime.Now;

        public ICollection<Stock> Stocks { get; set; }
    }
}
