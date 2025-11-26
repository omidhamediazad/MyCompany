using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;

namespace MyCompany.Shop.Application.Features.Orders.Queries;

// This query carries the order Id and expects an OrderDto as result
public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDto?>;

