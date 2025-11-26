using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyCompany.Shop.Application.DTOs;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MyCompany.Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly ShopDbContext _db;
    public AdminController(ShopDbContext db) => _db = db;

    // Add a new product
    [HttpPost("products")]
    public async Task<ActionResult<ProductDto>> AddProduct([FromBody] CreateProductRequest request)
    {
        var product = new Product(request.Name, request.Price, request.Stock);
        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        var dto = new ProductDto(product.Id, product.Name, product.Price, product.Stock, product.CreatedAt);
        return Ok(dto);
    }

    // Update an existing product
    [HttpPut("products/{id}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return NotFound($"Product {id} not found.");

        product.Update(request.Name, request.Price, request.Stock);
        await _db.SaveChangesAsync();

        var dto = new ProductDto(product.Id, product.Name, product.Price, product.Stock, product.CreatedAt);
        return Ok(dto);
    }

    // Delete a product
    [HttpDelete("products/{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return NotFound($"Product {id} not found.");

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
