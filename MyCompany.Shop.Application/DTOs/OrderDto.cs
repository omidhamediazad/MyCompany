using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.DTOs;

public record OrderDto(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    string Status,
    long AmountIrr,
    DateTime CreatedAt
);
