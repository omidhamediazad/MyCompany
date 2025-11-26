using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.DTOs;

public record ProductDto(Guid Id, string Name, decimal Price, int Stock, DateTime CreatedAt);
public record CreateProductRequest(string Name, decimal Price, int Stock);
public record UpdateProductRequest(string Name, decimal Price, int Stock);
