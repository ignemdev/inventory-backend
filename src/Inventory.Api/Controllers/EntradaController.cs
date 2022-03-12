using AutoMapper;
using Inventory.Core.DTOs.Entradas;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/entrada")]
public class EntradaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEntradaServices _entradaServices;
    public EntradaController(
        IEntradaServices entradaServices,
        IMapper mapper)
    {
        _entradaServices = entradaServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<EntradaDetail>>>> GetAllEntradaes()
    {
        var response = new ResponseModel<IEnumerable<EntradaDetail>>();
        try
        {
            var entradaes = await _entradaServices.GetAllEntradas();
            response.Data = _mapper.Map<IEnumerable<EntradaDetail>>(entradaes);

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
    public async Task<ActionResult<ResponseModel<EntradaDetail>>> GetEntradaById(int id)
    {
        var response = new ResponseModel<EntradaDetail>();
        try
        {
            var entrada = await _entradaServices.GetEntradaById(id);
            response.Data = _mapper.Map<EntradaDetail>(entrada);

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
    public async Task<ActionResult<ResponseModel<EntradaDetail>>> AddEntrada([FromBody] EntradaAdd entradaAdd)
    {
        var response = new ResponseModel<EntradaDetail>();
        try
        {
            var entrada = _mapper.Map<Entrada>(entradaAdd);
            var addedEntrada = await _entradaServices.AddEntrada(entrada);
            response.Data = _mapper.Map<EntradaDetail>(addedEntrada);

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

    [HttpPut]
    public async Task<ActionResult<ResponseModel<EntradaDetail>>> UpdateEntrada([FromBody] EntradaEdit entradaEdit)
    {
        var response = new ResponseModel<EntradaDetail>();
        try
        {
            var entrada = _mapper.Map<Entrada>(entradaEdit);
            var updatedEntrada = await _entradaServices.UpdateEntrada(entrada);
            response.Data = _mapper.Map<EntradaDetail>(updatedEntrada);

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

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ResponseModel<EntradaDetail>>> UpdateEntrada(int id)
    {
        var response = new ResponseModel<EntradaDetail>();
        try
        {
            var deletedEntrada = await _entradaServices.DeleteEntradaById(id);
            response.Data = _mapper.Map<EntradaDetail>(deletedEntrada);

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