using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.DTOs;

public class CreateOrderRequest
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
}
