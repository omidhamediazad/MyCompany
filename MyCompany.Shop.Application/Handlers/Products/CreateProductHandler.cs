using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.Features.Products.Commands;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Domain.Interfaces;

namespace MyCompany.Shop.Application.Handlers.Products;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repo;

    public CreateProductHandler(IProductRepository repo) => _repo = repo;

    public async Task<Guid> Handle(CreateProductCommand cmd, CancellationToken ct)
    {
        var p = new Product(cmd.Request.Name, cmd.Request.Price, cmd.Request.Stock);
        await _repo.AddAsync(p, ct);
        await _repo.SaveChangesAsync(ct);
        return p.Id;
    }
}

