using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.SalesOrderHeaders.Queries
{
    public class SalesOrderDetailQueryResult
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        [Required]
        public short OrderQty { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal UnitPriceDiscount { get; set; }

        [Required]
        public decimal LineTotal { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
