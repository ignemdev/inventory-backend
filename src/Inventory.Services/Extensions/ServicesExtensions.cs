using Inventory.Core.Services;
using Inventory.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class ServicesExtensions
{
    public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioServices, UsuarioServices>();

        return services;
    }
}
