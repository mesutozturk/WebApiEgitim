using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; set; }
}