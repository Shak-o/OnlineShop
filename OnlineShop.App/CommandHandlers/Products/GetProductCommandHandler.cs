using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class GetProductCommandHandler : IRequestHandler<GetProductCommand, ProductQueryResult>
    {
        private readonly IProductRepository _repository;
        private readonly IProductCategoryRepository _productCategoryRepo;
        private readonly IRepository<ProductModel> _productModelRepo;

        private readonly IMapper _mapper;

        public GetProductCommandHandler(IProductRepository repository, IMapper mapper, IProductCategoryRepository productCategoryRepo, IRepository<ProductModel> productModelRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _productCategoryRepo = productCategoryRepo;
            _productModelRepo = productModelRepo;
        }

        public async Task<ProductQueryResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetFirstNoTrackingAsync(x => x.Id == request.Id, cancellationToken);
                if (result.ProductCategoryId is not null)
                {
                    var productCategory = await _productCategoryRepo.GetFirstNoTrackingAsync(x => x.Id == result.ProductCategoryId, cancellationToken);
                    result.ProductCategory = productCategory;
                }

                if (result.ProductModelId is not null)
                {
                    var productModel = await _productModelRepo.GetFirstNoTrackingAsync(x => x.Id == result.ProductModelId, cancellationToken);
                    result.ProductModel = productModel;
                }
                
                var convert = _mapper.Map<Product, ProductQueryResult>(result);
                return convert;
            }
            catch (Exception ex)
            {
                throw new AppException($"Error during get {ex.Message}");
            }
        }
    }
}
