using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace MyCompany.Shop.Application.Features.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;
