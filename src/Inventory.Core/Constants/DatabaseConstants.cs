using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class DatabaseConstants
{
    #region names
    public const string DefaultDbContextName = "InventoryContext";
    public const string UsersTableName = "Usuarios";
    public const string LoginsTableName = "Logins";
    public const string TokensTableName = "Tokens";
    public const string ClaimsTableName = "Claims";
    public const string UsersRolesTableName = "UsuariosRoles";
    public const string RolesClaimsTableName = "RolesClaims";
    public const string RolesTableName = "Roles";
    #endregion

    #region fields
    public const int StockFieldMaxRange = 100000;

    public const float PrecioFieldMinRange = 10.00f;
    public const float PrecioFieldMaxRange = 100000.00f;

    public const int CantidadFieldMinRange = 1;
    public const int CantidadFieldMaxRange = 10000;

    public const int UnidadDescripcionMaxLength = 200;
    public const int RazonDescripcionMaxLength = 200;
    public const int ProductoNombreMaxLength = 150;
    public const int ProductoDescripcionMaxLength = 300;
    #endregion
}
