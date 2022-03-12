using AutoMapper;
using Inventory.Core.DTOs.Usuarios;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUsuarioServices _usuarioServices;
    public UsuarioController(
        IUsuarioServices usuarioServices, 
        IMapper mapper)
    {
        _usuarioServices = usuarioServices;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ResponseModel<UsuarioTokenDetail>>> RegisterUsuario([FromBody] UsuarioRegister usuarioRegister)
    {
        var response = new ResponseModel<UsuarioTokenDetail>();
        try
        {
            var usuario = _mapper.Map<Usuario>(usuarioRegister);
            var registeredUsuario = await _usuarioServices.RegisterUsuario(usuario);
            response.Data = _mapper.Map<UsuarioTokenDetail>(registeredUsuario);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<ResponseModel<UsuarioTokenDetail>>> RegisterUsuario([FromBody] UsuarioLogin usuarioLogin)
    {
        var response = new ResponseModel<UsuarioTokenDetail>();
        try
        {
            var usuario = _mapper.Map<Usuario>(usuarioLogin);
            var loggedUsuario = await _usuarioServices.LoginUsuario(usuario);
            response.Data = _mapper.Map<UsuarioTokenDetail>(loggedUsuario);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }
}
