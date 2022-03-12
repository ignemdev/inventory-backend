using Inventory.Core.Entities;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services;

public class UsuarioServices : IUsuarioServices
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<Usuario> _userManager;
    public UsuarioServices(
        IConfiguration configuration,
        UserManager<Usuario> userManager
        )
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<Usuario> LoginUsuario(Usuario usuario)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(usuario, new ValidationContext(usuario), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        var dbUsuario = await _userManager.FindByNameAsync(usuario.UserName);

        if (dbUsuario == null)
            throw new NullReferenceException(Messages.E001);

        var isPasswordValid = await _userManager.CheckPasswordAsync(dbUsuario, usuario.Password);

        if (!isPasswordValid)
            throw new InvalidOperationException(Messages.E001);

        var jwtToken = GetUsuarioToken(dbUsuario);

        if (jwtToken == null)
            throw new InvalidOperationException(Messages.E002);

        dbUsuario.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return dbUsuario;
    }

    public async Task<Usuario> RegisterUsuario(Usuario usuario)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(usuario, new ValidationContext(usuario), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        var result = await _userManager.CreateAsync(usuario, usuario.Password);
        //valida existencia por correo
        if(!result.Succeeded)
            throw new InvalidOperationException(FormatedIdentityResultErrors(result.Errors));

        var dbUsuario = await _userManager.FindByNameAsync(usuario.UserName);

        var jwtToken = GetUsuarioToken(dbUsuario);

        if (jwtToken == null)
            throw new InvalidOperationException(Messages.E002);

        dbUsuario.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return dbUsuario;
    }

    public JwtSecurityToken GetUsuarioToken(Usuario usuario)
    {
        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }

    private string FormatedIdentityResultErrors(IEnumerable<IdentityError> errors)
    {
        var formatedErrors = new List<string>();

        errors.ToList().ForEach(e => formatedErrors.Add($"{e.Code}: {e.Description}"));

        var joinedErrors = string.Join('\n', formatedErrors);

        return joinedErrors;
    }
}
