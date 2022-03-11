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
}
