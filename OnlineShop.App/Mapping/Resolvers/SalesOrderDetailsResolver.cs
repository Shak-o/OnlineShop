using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.App.Mapping.Resolvers
{
    public class SalesOrderDetailsResolver : IValueResolver<SalesOrderDetail, SalesOrderDetailQueryResult, string>
    {
        public string Resolve(SalesOrderDetail source, SalesOrderDetailQueryResult destination, string destMember,
            ResolutionContext context)
        {
            return source.ProductId.ToString();
        }
    }
}
