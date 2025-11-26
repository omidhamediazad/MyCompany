using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace MyCompany.Shop.Application.Features.Payments.Commands
{
    // Command برای تایید پرداخت
    public record VerifyPaymentCommand(Guid PaymentId) : IRequest<bool>;
}
