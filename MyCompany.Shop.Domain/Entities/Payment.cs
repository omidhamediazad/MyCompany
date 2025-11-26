using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;

namespace MyCompany.Shop.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public string Status { get; private set; } = "Pending";
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // تاریخ پرداخت (nullable چون ممکنه هنوز پرداخت نشده باشد)
        public DateTime? PaidAt { get; private set; }

        // EF Core نیاز به سازنده‌ی بدون پارامتر دارد
        private Payment() { }

        // سازنده‌ی اصلی برای ایجاد پرداخت جدید
        public Payment(Guid orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
            Status = "Pending";
        }

        // متد برای تغییر وضعیت به Paid و ثبت زمان پرداخت
        public void MarkPaid()
        {
            Status = "Paid";
            PaidAt = DateTime.UtcNow;
        }
    }
}
