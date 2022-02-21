using AutoMapper;
using Cannabis.Core.Entities;
using Cannabis.Api.Dtos;

namespace Cannabis.Api.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config) => _config = config;

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
            => !string.IsNullOrEmpty(source.PictureUrl) ?  _config["ApiUrl"] + source.PictureUrl : null;
    }
}