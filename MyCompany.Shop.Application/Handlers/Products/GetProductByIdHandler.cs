using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;
using MyCompany.Shop.Application.Features.Products.Queries;
using MyCompany.Shop.Domain.Interfaces;

namespace MyCompany.Shop.Application.Handlers.Products;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repo;
    public GetProductByIdHandler(IProductRepository repo) => _repo = repo;

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var p = await _repo.GetByIdAsync(request.Id, ct);
        return p is null ? null : new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.CreatedAt);
    }
}

