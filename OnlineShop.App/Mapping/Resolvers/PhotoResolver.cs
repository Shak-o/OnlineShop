using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.App.Mapping.Resolvers
{
    public class PhotoResolver : IValueResolver<Product, ProductQueryResult, string>
    {
        public string Resolve(Product source, ProductQueryResult destination, string destMember, ResolutionContext context)
        {
            if (source.ThumbNailPhoto is null)
                return string.Empty;

            var result = Convert.ToBase64String(source.ThumbNailPhoto);
            return result;
        }
    }
}
