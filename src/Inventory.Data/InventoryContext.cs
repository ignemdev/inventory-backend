using Inventory.Core.Entities;
using Microsoft.AspNetCore.Http;
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

    public DbSet<Unidad> Unidades { get; set; } = null!;
    public DbSet<Razon> Razones { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Entrada> Entradas { get; set; } = null!;
    public DbSet<Salida> Salidas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddUnidadesMapping();
        builder.AddRazonesMapping();
        builder.AddProductosMapping();
        builder.AddEntradasMapping();
        builder.AddSalidasMapping();

        base.OnModelCreating(builder);

        builder.AddIdentityMapping();
    }

    public Task<int> SaveChangesWithUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Creado = DateTime.Now;
                entityEntry.Entity.Modificado = DateTime.Now;
                entityEntry.Entity.CreadorId = usuarioId;
                entityEntry.Entity.ModificadorId = usuarioId;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Modificado = DateTime.Now;
                entityEntry.Entity.ModificadorId = usuarioId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveChangesWithTimestampsAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Creado = DateTime.Now;
                entityEntry.Entity.Modificado = DateTime.Now;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Modificado = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
