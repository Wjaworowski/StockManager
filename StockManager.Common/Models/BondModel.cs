namespace StockManager.Common.Models
{
    /// <summary>
    /// Bond Stock Model.
    /// </summary>
    /// <seealso cref="StockManager.Common.Models.BaseStock" />
    public class BondModel : BaseStock
    {
        /// <summary>
        /// Gets the commision percent of a Bond.
        /// </summary>
        /// <value>
        /// The commision percent.
        /// </value>
        public override double CommisionPercent => 0.02;
    }
}
