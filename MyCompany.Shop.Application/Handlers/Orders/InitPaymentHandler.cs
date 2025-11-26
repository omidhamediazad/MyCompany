using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCompany.Shop.Application.Features.Orders.Commands;
using MyCompany.Shop.Application.Features.Payments.Commands;
using MyCompany.Shop.Domain.Entities;
using MyCompany.Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitPaymentCommand = MyCompany.Shop.Application.Features.Payments.Commands.InitPaymentCommand;

namespace MyCompany.Shop.Application.Handlers.Payments;

public class InitPaymentHandler : IRequestHandler<InitPaymentCommand, Guid>
{
    private readonly ShopDbContext _db;
    public InitPaymentHandler(ShopDbContext db) => _db = db;

    public async Task<Guid> Handle(InitPaymentCommand command, CancellationToken ct)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == command.OrderId, ct);
        if (order is null) throw new Exception($"Order {command.OrderId} not found.");

        var payment = new Payment(order.Id, order.Amount);
        _db.Payments.Add(payment);
        await _db.SaveChangesAsync(ct);

        return payment.Id;
    }
}
