using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Addresses.Queries
{
    public class AddressQuery
    {
        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; } = null!;

        [StringLength(60)]
        public string? AddressLine2 { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string StateProvince { get; set; } = null!;
     
        [Required]
        [StringLength(50)]
        public string CountryRegion { get; set; } = null!;

        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; } = null!;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public int Id { get; set; }
    }
}
