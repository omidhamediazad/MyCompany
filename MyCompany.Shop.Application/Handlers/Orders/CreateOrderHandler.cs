using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;
using MyCompany.Shop.Application.Features.Orders.Commands;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Infrastructure.Persistence;

namespace MyCompany.Shop.Application.Handlers.Orders;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly ShopDbContext _db;
    public CreateOrderHandler(ShopDbContext db) => _db = db;

    public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken ct)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            ProductId = command.Request.ProductId,
            UserId = command.Request.UserId,
            Amount = 0, // set from product price later
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync(ct);
        return order.Id;
    }
}
