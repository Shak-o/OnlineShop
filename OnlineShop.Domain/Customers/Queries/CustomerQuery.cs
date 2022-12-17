using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Addresses.Queries;

namespace OnlineShop.Domain.Customers.Queries
{
    public class CustomerQuery
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AccountId { get; set; }

        [StringLength(8)]
        public string? Title { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string MiddleName { get; set; } = null!;

        public string? Password { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(10)]
        public string? Suffix { get; set; }

        [StringLength(128)]
        public string? CompanyName { get; set; }

        [StringLength(256)]
        public string? SalesPerson { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(25)]
        public string? Phone { get; set; }

        /// <summary>
        /// Address Count
        /// </summary>
        public int NumberOfAddresses { get; set; }

        public List<AddressQuery> Addresses { get; set; }
    }
}
