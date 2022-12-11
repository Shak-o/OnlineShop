﻿using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<List<ProductCategoryListQueryResult>> GetProductCategoriesAsync(int count, int page);
    }
}
