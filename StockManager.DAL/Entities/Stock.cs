namespace StockManager.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    using StockManager.Common.Enums;

    /// <summary>
    /// Stock entity.
    /// </summary>
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double CommisionPercent { get; set; }

        [Required]
        public StockType StockType { get; set; }
    }
}
