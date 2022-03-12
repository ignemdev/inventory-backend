using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;

public class Usuario : IdentityUser<int>
{
    [Required]
    public override string UserName { get => base.UserName; set => base.UserName = value; }

    [EmailAddress]
    public override string Email { get => base.Email; set => base.Email = value; }

    [NotMapped]
    public string Token { get; set; } = null!;

    [NotMapped]
    [Required]
    public string Password { get; set; } = null!;
}
