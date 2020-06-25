namespace ModelsLibrary.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public double InitialPrice { get; set; }
        public double? TargetPrice { get; set; }
        //public int ChangeAlert { get; set; } //default to 5%
        public double LastAlertPrice { get; set; } //set initially to initial price
        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public int SymbolId { get; set; }
        public Symbol Symbol { get; set; }
    }
}
