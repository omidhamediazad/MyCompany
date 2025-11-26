using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCompany.Shop.Application.Features.Payments.Commands;
using MyCompany.Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.Handlers.Payments
{
    public class VerifyPaymentHandler : IRequestHandler<VerifyPaymentCommand, bool>
    {
        private readonly ShopDbContext _db;
        public VerifyPaymentHandler(ShopDbContext db) => _db = db;

        public async Task<bool> Handle(VerifyPaymentCommand command, CancellationToken ct)
        {
            // پیدا کردن پرداخت
            var payment = await _db.Payments.FirstOrDefaultAsync(p => p.Id == command.PaymentId, ct);
            if (payment is null) return false;

            // تغییر وضعیت پرداخت
            payment.MarkPaid();

            // پیدا کردن سفارش مرتبط و تغییر وضعیت آن
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == payment.OrderId, ct);
            if (order is not null)
            {
                order.MarkPaid();
            }

            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
