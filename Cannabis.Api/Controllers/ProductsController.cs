using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;

namespace Cannabis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController :  ControllerBase
{
    private readonly IProductRepository _prodcut;
    public ProductsController(IProductRepository prodcut)
    {
        _prodcut = prodcut;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var data = await _prodcut.Get();
        return !data.Any() ? NotFound() : Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var data = await _prodcut.Get(id);
        return data == null ? NotFound() : Ok(data);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<List<ProductBrand>>> GetBrands()
    {
        var data = await _prodcut.GetBrands();
        return!data.Any() ? NotFound() : Ok(data);
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<ProductType>>> GetTypes()
    {
        var data = await _prodcut.GetTypes();
        return !data.Any() ? NotFound() : Ok(data);
    }
}
