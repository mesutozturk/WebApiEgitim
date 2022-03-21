using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Data;
using WebApi1.Dtos;
using WebApi1.Models;

namespace WebApi1.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : Controller
{
    private readonly MyContext _context;

    public ProductController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("get")]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpPost("add")]
    public IActionResult AddProduct(ProductAddRequest model)
    {
        if (model.Price <= 0)
        {
            throw new Exception("Ürün fiyatı 0dan büyük olamaz");
            return BadRequest("Ürün fiyatı 0dan büyük olmalıdır");
        }
        var data = new Product()
        {
            Name = model.Name,
            Price = model.Price
        };
        _context.Products.Add(data);
        _context.SaveChanges();
        return Ok(data);
    }
}