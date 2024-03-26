using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using ProductModel = Product.API.Models.Product;

namespace Product.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public ActionResult Greetings() => Ok("Hello, I'm alive!");

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> GetItem(int id)
    {
        _context.Database.EnsureCreated();

        var item = await _context.Products.FindAsync(id);

        if (item == null)
            return NotFound();

        return item;
    }
}
