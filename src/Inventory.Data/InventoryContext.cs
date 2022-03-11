using Inventory.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data;

public class InventoryContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.AddIdentityMappings();
    }
}
