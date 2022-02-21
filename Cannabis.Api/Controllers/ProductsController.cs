using Microsoft.AspNetCore.Mvc;
using Cannabis.Api.Dtos;
using Cannabis.Core.Entities;
using Cannabis.Core.Specifitactions;
using Cannabis.Core.Interfaces.Repositories;
using AutoMapper;

namespace Cannabis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController :  ControllerBase
{
    private readonly IGenericRepository<Product> _product;
    private readonly IGenericRepository<ProductBrand> _brand;
    private readonly IGenericRepository<ProductType> _type;
    private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> product, IGenericRepository<ProductBrand> brand, IGenericRepository<ProductType> type, IMapper mapper)
    
    {
        _product = product;
        _brand = brand;
        _type = type;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> Get()
    {
        var products = await _product.ListAsync(new ProductsSpecification());
        return !products.Any() ? NotFound() : Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var product = await _product.GetEntityWithSpec(new ProductsSpecification(id));
        return product == null ? NotFound() : Ok(_mapper.Map<Product, ProductDto>(product));
    }

    [HttpGet("brands")]
    public async Task<ActionResult<List<ProductBrand>>> GetBrands()
    {
        var data = await _brand.ListAllAsync();
        return !data.Any() ? NotFound() : Ok(data);
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<ProductType>>> GetTypes()
    {
        var data = await _type.ListAllAsync();
        return !data.Any() ? NotFound() : Ok(data);
    }
}
