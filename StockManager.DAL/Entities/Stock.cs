namespace StockManager.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    using StockManager.Common.Enums;

    /// <summary>
    /// Stock entity.
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the commision percent.
        /// </summary>
        /// <value>
        /// The commision percent.
        /// </value>
        public double CommisionPercent { get; set; }

        /// <summary>
        /// Gets or sets the type of the stock.
        /// </summary>
        /// <value>
        /// The type of the stock.
        /// </value>
        [Required]
        public StockType StockType { get; set; }
    }
}
