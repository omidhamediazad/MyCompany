using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;

namespace MyCompany.Shop.Application.Features.Orders.Commands;

// This command carries the request data and expects a Guid (order Id) as result
public record CreateOrderCommand(CreateOrderRequest Request) : IRequest<Guid>;
