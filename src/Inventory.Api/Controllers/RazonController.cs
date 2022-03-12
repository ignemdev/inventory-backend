using AutoMapper;
using Inventory.Core.DTOs.Razones;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;


[Authorize]
[ApiController]
[Route("api/razon")]
public class RazonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRazonServices _razonServices;
    public RazonController(
        IRazonServices razonServices,
        IMapper mapper)
    {
        _razonServices = razonServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<RazonDetail>>>> GetAllRazones()
    {
        var response = new ResponseModel<IEnumerable<RazonDetail>>();
        try
        {
            var razones = await _razonServices.GetAllRazones();
            response.Data = _mapper.Map<IEnumerable<RazonDetail>>(razones);

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
    public async Task<ActionResult<ResponseModel<RazonDetail>>> GetRazonById(int id)
    {
        var response = new ResponseModel<RazonDetail>();
        try
        {
            var razon = await _razonServices.GetRazonById(id);
            response.Data = _mapper.Map<RazonDetail>(razon);

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
    public async Task<ActionResult<ResponseModel<RazonDetail>>> AddRazon([FromBody] RazonAdd razonAdd)
    {
        var response = new ResponseModel<RazonDetail>();
        try
        {
            var razon = _mapper.Map<Razon>(razonAdd);
            var addedRazon = await _razonServices.AddRazon(razon);
            response.Data = _mapper.Map<RazonDetail>(addedRazon);

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
    public async Task<ActionResult<ResponseModel<RazonDetail>>> UpdateRazon([FromBody] RazonEdit razonEdit)
    {
        var response = new ResponseModel<RazonDetail>();
        try
        {
            var razon = _mapper.Map<Razon>(razonEdit);
            var updatedRazon = await _razonServices.UpdateRazon(razon);
            response.Data = _mapper.Map<RazonDetail>(updatedRazon);

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