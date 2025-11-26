using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;

namespace MyCompany.Shop.Application.Features.Products.Commands;

public record UpdateProductCommand(Guid Id, UpdateProductRequest Request) : IRequest<bool>;
