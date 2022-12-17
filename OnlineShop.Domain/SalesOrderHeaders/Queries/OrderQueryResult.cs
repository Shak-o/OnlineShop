using System.ComponentModel.DataAnnotations;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Domain.SalesOrderHeaders.Queries
{
    public class OrderQueryResult
    {
        public int Id { get; set; }

        [Required]
        public byte RevisionNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        [Required]
        public byte Status { get; set; }

        [Required]
        public bool OnlineOrderFlag { get; set; }


        public string? AccountNumber { get; set; }

        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// The ID of the location to send goods.  Foreign key to the Address table.
        /// </summary>
        public int? ShipToAddressId { get; set; }

        /// <summary>
        /// The ID of the location to send invoices.  Foreign key to the Address table.
        /// </summary>
        public int? BillToAddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShipMethod { get; set; } = null!;

        [StringLength(15)]
        public string? CreditCardApprovalCode { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal TaxAmt { get; set; }

        [Required]
        public decimal Freight { get; set; }

        [Required]
        public decimal TotalDue { get; set; }

        /// <summary>
        /// Sales representative comments.
        /// </summary>
        public string? Comment { get; set; }

        public virtual AddressQuery? BillToAddress { get; set; }

        public virtual CustomerQuery Customer { get; set; } = null!;

        public virtual List<SalesOrderDetailQueryResult> SalesOrderDetails { get; set; } = new List<SalesOrderDetailQueryResult>();

        public virtual AddressQuery? ShipToAddress { get; set; }
    }
}
