using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface IUsuarioServices
{
    Task<Usuario> LoginUsuario(Usuario usuario);
    Task<Usuario> RegisterUsuario(Usuario usuario);
    JwtSecurityToken GetUsuarioToken(Usuario usuario);
}
