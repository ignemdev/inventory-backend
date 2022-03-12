using AutoMapper;
using Inventory.Core.DTOs.Unidades;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/unidad")]
public class UnidadController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnidadServices _unidadServices;
    public UnidadController(
        IUnidadServices unidadServices, 
        IMapper mapper)
    {
        _unidadServices = unidadServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<UnidadDetail>>>> GetAllUnidades()
    {
        var response = new ResponseModel<IEnumerable<UnidadDetail>>();
        try
        {
            var unidades = await _unidadServices.GetAllUnidades();
            response.Data = _mapper.Map<IEnumerable<UnidadDetail>>(unidades);

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
    public async Task<ActionResult<ResponseModel<UnidadDetail>>> GetUnidadById(int id)
    {
        var response = new ResponseModel<UnidadDetail>();
        try
        {
            var unidad = await _unidadServices.GetUnidadById(id);
            response.Data = _mapper.Map<UnidadDetail>(unidad);

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
    public async Task<ActionResult<ResponseModel<UnidadDetail>>> AddUnidad([FromBody] UnidadAdd unidadAdd)
    {
        var response = new ResponseModel<UnidadDetail>();
        try
        {
            var unidad = _mapper.Map<Unidad>(unidadAdd);
            var addedUnidad = await _unidadServices.AddUnidad(unidad);
            response.Data = _mapper.Map<UnidadDetail>(addedUnidad);

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
    public async Task<ActionResult<ResponseModel<UnidadDetail>>> UpdateUnidad([FromBody] UnidadEdit unidadEdit)
    {
        var response = new ResponseModel<UnidadDetail>();
        try
        {
            var unidad = _mapper.Map<Unidad>(unidadEdit);
            var updatedUnidad = await _unidadServices.UpdateUnidad(unidad);
            response.Data = _mapper.Map<UnidadDetail>(updatedUnidad);

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
