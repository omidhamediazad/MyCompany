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

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IProductRepository _repo;

    public GetProductsHandler(IProductRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsQuery request, CancellationToken ct)
    {
        var items = await _repo.GetPagedAsync(request.Page, request.PageSize, ct);
        return items.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.CreatedAt)).ToList();
    }
}
