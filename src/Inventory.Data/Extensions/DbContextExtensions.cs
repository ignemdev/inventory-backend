using Inventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class DbContextExtensions
{
    public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InventoryContext>(options => options.UseSqlServer(configuration.GetConnectionString(DatabaseConstants.DefaultDbContextName)));

        return services;
    }
}
