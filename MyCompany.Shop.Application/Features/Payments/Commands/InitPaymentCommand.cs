using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace MyCompany.Shop.Application.Features.Payments.Commands;

// Command to initialize a payment for an order
public record InitPaymentCommand(Guid OrderId) : IRequest<Guid>;
