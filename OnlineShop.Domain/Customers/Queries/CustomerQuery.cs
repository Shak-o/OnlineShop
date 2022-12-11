using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Addresses.Queries;

namespace OnlineShop.Domain.Customers.Queries
{
    public class CustomerQuery
    {
        public int Id { get; set; }
        /// <summary>
        /// First name of the person.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Middle name
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Last name of the person.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// The customer&apos;s organization.
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// E-mail address for the person.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Phone number associated with the person.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Address Count
        /// </summary>
        public int NumberOfAddresses { get; set; }

        public List<AddressQuery> Addresses { get; set; }
    }
}
