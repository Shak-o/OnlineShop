using System;
using System.Collections.Generic;
using OnlineShop.Domain.Products;

namespace OnlineShop.Domain.Models;

public partial class ProductModel : IBaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CatalogDescription { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; } = new List<ProductModelProductDescription>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public void Dispose()
    {
    }
}
