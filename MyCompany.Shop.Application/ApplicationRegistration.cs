using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyCompany.Shop.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register all MediatR handlers in this assembly
        services.AddMediatR(typeof(ApplicationRegistration).Assembly);

        return services;
    }
}
