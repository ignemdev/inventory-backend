using AutoMapper;
using Inventory.Core.DTOs.Salidas;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/salida")]
public class SalidaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISalidaServices _salidaServices;
    public SalidaController(
        ISalidaServices salidaServices,
        IMapper mapper)
    {
        _salidaServices = salidaServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<SalidaDetail>>>> GetAllSalidas()
    {
        var response = new ResponseModel<IEnumerable<SalidaDetail>>();
        try
        {
            var salidaes = await _salidaServices.GetAllSalidas();
            response.Data = _mapper.Map<IEnumerable<SalidaDetail>>(salidaes);

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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResponseModel<SalidaDetail>>> GetSalidaById(int id)
    {
        var response = new ResponseModel<SalidaDetail>();
        try
        {
            var salida = await _salidaServices.GetSalidaById(id);
            response.Data = _mapper.Map<SalidaDetail>(salida);

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

    [HttpPost]
    public async Task<ActionResult<ResponseModel<SalidaDetail>>> AddSalida([FromBody] SalidaAdd salidaAdd)
    {
        var response = new ResponseModel<SalidaDetail>();
        try
        {
            var salida = _mapper.Map<Salida>(salidaAdd);
            var addedSalida = await _salidaServices.AddSalida(salida);
            response.Data = _mapper.Map<SalidaDetail>(addedSalida);

            if (response.Data == null)
                return NotFound();

            return StatusCode(201, response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }
}