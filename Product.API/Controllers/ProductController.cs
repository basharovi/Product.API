using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using ProductModel = Product.API.Models.Product;

namespace Product.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> GetItem(int id)
    {
        var item = await _context.Products.FindAsync(id);

        if (item == null)
            return NotFound();

        return item;
    }
}
