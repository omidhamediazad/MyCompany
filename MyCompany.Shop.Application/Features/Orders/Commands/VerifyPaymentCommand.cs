using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;

namespace MyCompany.Shop.Application.Features.Orders.Commands;

// This command carries the order Id and the payment status request.
// It expects a bool result (true if payment verified successfully).
public record VerifyPaymentCommand(Guid OrderId, VerifyPaymentRequest Request) : IRequest<bool>;
