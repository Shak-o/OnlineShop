using AutoMapper;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Queries;
using System.Text;

namespace OnlineShop.App.Mapping.Resolvers
{
    public class PhotoReverseResolver : IValueResolver<ProductQueryResult, Product, byte[]?>
    {
        public byte[]? Resolve(ProductQueryResult source, Product destination, byte[]? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.ThumbNailPhotoBase64) && source.ThumbNailPhoto.Length == 0)
                return null;

            if (source.ThumbNailPhoto.Length > 0)
                return source.ThumbNailPhoto;

            var photo = Convert.FromBase64String(source.ThumbNailPhotoBase64);

            return photo;
        }
    }
}
