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
    public async Task<ActionResult<ResponseModel<UsuarioResponse>>> RegisterUsuario([FromBody] UsuarioRegisterRequest usuarioRegisterRequest)
    {
        var response = new ResponseModel<UsuarioResponse>();
        try
        {
            var usuario = _mapper.Map<Usuario>(usuarioRegisterRequest);
            var registeredUsuario = await _usuarioServices.RegisterUsuario(usuario);
            response.Data = _mapper.Map<UsuarioResponse>(registeredUsuario);

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
    public async Task<ActionResult<ResponseModel<UsuarioResponse>>> RegisterUsuario([FromBody] UsuarioLoginRequest usuarioLoginRequest)
    {
        var response = new ResponseModel<UsuarioResponse>();
        try
        {
            var usuario = _mapper.Map<Usuario>(usuarioLoginRequest);
            var loggedUsuario = await _usuarioServices.LoginUsuario(usuario);
            response.Data = _mapper.Map<UsuarioResponse>(loggedUsuario);

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
