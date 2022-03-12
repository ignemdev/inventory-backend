using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DTOs.Usuarios;

public class UsuarioLogin
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
