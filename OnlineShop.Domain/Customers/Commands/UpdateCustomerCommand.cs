using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using OnlineShop.Domain.Addresses.Queries;

namespace OnlineShop.Domain.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public bool NameStyle { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? CompanyName { get; set; }
        public string? SalesPerson { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<AddressQuery> AddressQueries { get; set; }
    }
}
