namespace OnlineShop.Domain.SalesOrderHeaders.Queries
{
    public class OrderListQueryResult
    {
        public int Id { get; set; }
        /// <summary>
        /// Dates the sales order was created.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Date the order is due to the customer.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Customer identification number. Foreign key to Customer.CustomerID.
        /// </summary>
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        /// <summary>
        /// The ID of the location to send goods.  Foreign key to the Address table.
        /// </summary>
        public int? ShipToAddressId { get; set; }


        /// <summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        /// </summary>
        public decimal SubTotal { get; set; }

        public decimal TotalDue { get; set; }

        /// <summary>
        /// Sales representative comments.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
