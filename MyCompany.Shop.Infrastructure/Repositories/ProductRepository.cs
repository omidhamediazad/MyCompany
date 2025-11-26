using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Domain.Interfaces;
using MyCompany.Shop.Infrastructure.Persistence;

namespace MyCompany.Shop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _ctx;
    public ProductRepository(ShopDbContext ctx) => _ctx = ctx;

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _ctx.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<IReadOnlyList<Product>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default) =>
        await _ctx.Products.OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

    public async Task AddAsync(Product product, CancellationToken ct = default) =>
        await _ctx.Products.AddAsync(product, ct);

    public Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        _ctx.Products.Update(product);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product, CancellationToken ct = default)
    {
        _ctx.Products.Remove(product);
        return Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _ctx.SaveChangesAsync(ct);
}
