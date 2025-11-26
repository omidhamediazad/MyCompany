using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Domain.Entities;

public class Delivery
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;

    public string Channel { get; set; } = "Dashboard"; // e.g. Email, Dashboard
    public string Payload { get; set; } = default!;     // account info or instructions
    public string Status { get; set; } = "Pending";    // Pending, Sent
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? SentAt { get; set; }
}
