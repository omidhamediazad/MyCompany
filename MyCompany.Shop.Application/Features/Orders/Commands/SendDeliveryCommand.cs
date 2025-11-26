using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Domain.Entities;

namespace MyCompany.Shop.Application.Features.Orders.Commands;

// This command carries the order Id and expects a Delivery entity as result
public record SendDeliveryCommand(Guid OrderId) : IRequest<Delivery?>;
