using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCompany.Shop.Application.DTOs;
using MyCompany.Shop.Application.Features.Orders.Queries;
using MyCompany.Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.Handlers.Orders;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly ShopDbContext _db;
    public GetOrderByIdHandler(ShopDbContext db) => _db = db;

    public async Task<OrderDto?> Handle(GetOrderByIdQuery query, CancellationToken ct)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == query.Id, ct);
        if (order is null) return null;

        // Make sure these properties exist in your Order entity
        return new OrderDto(
            order.Id,
            order.UserId,
            order.ProductId,
            order.Status,
            order.Amount,      // use "Amount" if your entity has it, not "AmountIrr"
            order.CreatedAt
        );
    }
}
