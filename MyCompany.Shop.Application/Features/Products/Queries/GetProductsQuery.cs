using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MyCompany.Shop.Application.DTOs;

namespace MyCompany.Shop.Application.Features.Products.Queries;

public record GetProductsQuery(int Page = 1, int PageSize = 20) : IRequest<IReadOnlyList<ProductDto>>;
