using Microsoft.AspNetCore.Mvc;
using Cannabis.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Cannabis.Core.Entities;

namespace Cannabis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController :  ControllerBase
{
    private readonly StoreContext _context;
    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var data = await _context.Products.ToListAsync();
        if(!data.Any()) return NotFound();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var data = await _context.Products.FindAsync(id);
        if(data == null) return NotFound();
        return Ok(data);
    }
}
