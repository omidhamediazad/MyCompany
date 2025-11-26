using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;

using System;

namespace MyCompany.Shop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Status { get; private set; } = "Pending";
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // سازنده‌ی بدون پارامتر برای EF Core
        protected Order() { }

        // سازنده‌ی اصلی
        public Order(Guid productId, Guid userId, decimal amount)
        {
            ProductId = productId;
            UserId = userId;
            Amount = amount;
            Status = "Pending";
        }

        // تغییر وضعیت سفارش به Paid
        public void MarkPaid()
        {
            Status = "Paid";
        }

        // تغییر وضعیت سفارش به Delivered
        public void MarkDelivered()
        {
            Status = "Delivered";
        }
    }
}
