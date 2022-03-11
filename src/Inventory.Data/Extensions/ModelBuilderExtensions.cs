using Inventory.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class ModelBuilderExtensions
{
    public static ModelBuilder AddIdentityMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable(DatabaseConstants.UsersTableName)
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.EmailConfirmed);
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable(DatabaseConstants.LoginsTableName);
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable(DatabaseConstants.TokensTableName);
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable(DatabaseConstants.ClaimsTableName);
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable(DatabaseConstants.UsersRolesTableName);
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable(DatabaseConstants.RolesClaimsTableName);
        modelBuilder.Entity<IdentityRole<int>>().ToTable(DatabaseConstants.RolesTableName);

        return modelBuilder;
    }

    public static ModelBuilder AddUnidadesMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.Property(u => u.Descripcion)
               .IsRequired()
               .HasMaxLength(DatabaseConstants.UnidadDescripcionMaxLength)
               .IsUnicode(false);
        }).AddBaseMappings();

        return modelBuilder;
    }

    public static ModelBuilder AddRazonesMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Razon>(entity =>
        {
            entity.Property(r => r.Descripcion)
               .IsRequired()
               .HasMaxLength(DatabaseConstants.RazonDescripcionMaxLength)
               .IsUnicode(false);
        }).AddBaseMappings();

        return modelBuilder;
    }

    public static ModelBuilder AddProductosMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.ProductoNombreMaxLength)
                .IsUnicode(false);

            entity.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.ProductoDescripcionMaxLength)
                .IsUnicode(false);

            entity.Property(p => p.Stock)
                .IsRequired();

            entity.Property(p => p.Precio)
                .IsRequired();

            entity.HasOne(p => p.Unidad)
                .WithMany()
                .HasForeignKey(p => p.UnidadId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }).AddBaseMappings();

        return modelBuilder;
    }

    public static ModelBuilder AddEntradasMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.Property(e => e.Cantidad)
                .IsRequired();
        
            entity.HasOne(e => e.Producto)
                .WithMany()
                .HasForeignKey(e => e.ProductoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        
        }).AddBaseMappings();

        return modelBuilder;
    }

    public static ModelBuilder AddSalidasMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salida>(entity =>
        {
            entity.Property(s => s.Cantidad)
                .IsRequired();

            entity.HasOne(s => s.Producto)
                .WithMany()
                .HasForeignKey(s => s.ProductoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Razon)
                .WithMany()
                .HasForeignKey(s => s.RazonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }).AddBaseMappings();

        return modelBuilder;
    }

    private static ModelBuilder AddBaseMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntity>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.HasOne(b => b.Usuario)
                .WithMany()
                .HasForeignKey(b => b.UsuarioId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(b => b.Creado).HasColumnType("datetime");
            entity.Property(b => b.Modificado).HasColumnType("datetime");
        });

        return modelBuilder;
    }
}
