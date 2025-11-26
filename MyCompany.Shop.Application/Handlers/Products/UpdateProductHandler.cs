using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.Features.Products.Commands;
using MyCompany.Shop.Domain.Interfaces;

namespace MyCompany.Shop.Application.Handlers.Products;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repo;

    public UpdateProductHandler(IProductRepository repo) => _repo = repo;

    public async Task<bool> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        var p = await _repo.GetByIdAsync(cmd.Id, ct);
        if (p is null) return false;

        p.Update(cmd.Request.Name, cmd.Request.Price, cmd.Request.Stock);
        await _repo.UpdateAsync(p, ct);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}
