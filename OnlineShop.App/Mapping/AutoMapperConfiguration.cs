using AutoMapper;
using OnlineShop.App.Mapping.Resolvers;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Commands;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.App.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, CustomerQuery>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<Address, AddressQuery>();
            CreateMap<AddressQuery, Address>();
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<UpdateAddressCommand, Address>();

            CreateMap<ProductCategory, ProductCategoryQueryResult>();
            CreateMap<ProductCategoryQueryResult, ProductCategory>();
            CreateMap<CreateProductCategoryCommand, ProductCategory>();
            CreateMap<UpdateProductCategoryCommand, ProductCategory>();

            CreateMap<Product, ProductQueryResult>().ForMember(x => x.ThumbNailPhotoBase64, x => x.MapFrom<PhotoResolver>());
            CreateMap<ProductQueryResult, Product>().ForMember(x => x.ThumbNailPhoto, x => x.MapFrom<PhotoReverseResolver>());
            CreateMap<CreateProductCommand, Product>();
            CreateMap<ProductModel, ProductModelQueryResult>();
            CreateMap<ProductModelQueryResult, ProductModel>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<SalesOrderHeader, OrderQueryResult>(); 
            CreateMap<SalesOrderHeader, OrderListQueryResult>(); 
            CreateMap<CreateOrderCommand, SalesOrderHeader>(); 
            CreateMap<UpdateOrderCommand, SalesOrderHeader>();
            CreateMap<SalesOrderDetail, SalesOrderDetailQueryResult>();
            CreateMap<SalesOrderDetailQueryResult, SalesOrderDetail>();
        }
    }
}
