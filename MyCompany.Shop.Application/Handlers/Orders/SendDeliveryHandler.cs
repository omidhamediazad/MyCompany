using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MyCompany.Shop.Application.Features.Orders.Commands;

namespace MyCompany.Shop.Application.Handlers.Orders;

public class SendDeliveryHandler : IRequestHandler<SendDeliveryCommand, Delivery?>
{
    private readonly ShopDbContext _db;
    public SendDeliveryHandler(ShopDbContext db) => _db = db;

    public async Task<Delivery?> Handle(SendDeliveryCommand command, CancellationToken ct)
    {
        var order = await _db.Orders.Include(o => o.Delivery).FirstOrDefaultAsync(o => o.Id == command.OrderId, ct);
        if (order is null || order.Status != "Paid") return null;

        var delivery = new Delivery
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            Channel = "Dashboard",
            Payload = $"Your ChatGPT account is ready. Order: {order.Id}",
            Status = "Sent",
            SentAt = DateTime.UtcNow
        };

        _db.Deliveries.Add(delivery);
        order.Status = "Delivered";
        await _db.SaveChangesAsync(ct);

        return delivery;
    }
}
