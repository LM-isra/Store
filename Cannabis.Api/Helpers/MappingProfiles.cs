using AutoMapper;
using Cannabis.Core.Entities;
using Cannabis.Api.Dtos;
using Cannabis.Core.Entities.Identity;

namespace Cannabis.Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(x => x.ProductBrand, y => y.MapFrom(s => s.ProductBrand.Name))
            .ForMember(x => x.ProductType, y => y.MapFrom(s => s.ProductType.Name))
            .ForMember(x => x.PictureUrl, y => y.MapFrom<ProductUrlResolver>());
        
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}
