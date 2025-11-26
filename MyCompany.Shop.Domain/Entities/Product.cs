using MyCompany.Shop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Product() { }

    public Product(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Product name is required.");
        if (price <= 0) throw new DomainException("Price must be positive.");
        if (stock < 0) throw new DomainException("Stock cannot be negative.");

        Name = name;
        Price = price;
        Stock = stock;
    }

    public void Update(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Product name is required.");
        if (price <= 0) throw new DomainException("Price must be positive.");
        if (stock < 0) throw new DomainException("Stock cannot be negative.");

        Name = name;
        Price = price;
        Stock = stock;
    }
}
