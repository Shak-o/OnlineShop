using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnlineShop.Domain.Customers.Commands
{
    public class GetCustomersByPageCommand : IRequest<List<Customer>>
    {
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
