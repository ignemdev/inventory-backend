using AutoMapper;
using Inventory.Core.DTOs.Entradas;
using Inventory.Core.DTOs.Productos;
using Inventory.Core.DTOs.Salidas;
using Inventory.Core.Entities;
using Inventory.Core.Models;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/producto")]
public class ProductoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProductoServices _productoServices;
    public ProductoController(
        IProductoServices productoServices,
        IMapper mapper)
    {
        _productoServices = productoServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<ProductoDetail>>>> GetAllProductoes()
    {
        var response = new ResponseModel<IEnumerable<ProductoDetail>>();
        try
        {
            var productos = await _productoServices.GetAllProductos();
            response.Data = _mapper.Map<IEnumerable<ProductoDetail>>(productos);

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
    public async Task<ActionResult<ResponseModel<ProductoDetail>>> GetProductoById(int id)
    {
        var response = new ResponseModel<ProductoDetail>();
        try
        {
            var producto = await _productoServices.GetProductoById(id);
            response.Data = _mapper.Map<ProductoDetail>(producto);

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
    public async Task<ActionResult<ResponseModel<ProductoDetail>>> AddProducto([FromBody] ProductoAdd productoAdd)
    {
        var response = new ResponseModel<ProductoDetail>();
        try
        {
            var producto = _mapper.Map<Producto>(productoAdd);
            var addedProducto = await _productoServices.AddProducto(producto);
            response.Data = _mapper.Map<ProductoDetail>(addedProducto);

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
    public async Task<ActionResult<ResponseModel<ProductoDetail>>> UpdateProducto([FromBody] ProductoEdit productoEdit)
    {
        var response = new ResponseModel<ProductoDetail>();
        try
        {
            var producto = _mapper.Map<Producto>(productoEdit);
            var updatedProducto = await _productoServices.UpdateProducto(producto);
            response.Data = _mapper.Map<ProductoDetail>(updatedProducto);

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
    public async Task<ActionResult<ResponseModel<ProductoDetail>>> UpdateProducto(int id)
    {
        var response = new ResponseModel<ProductoDetail>();
        try
        {
            var deletedProducto = await _productoServices.DeleteProductoById(id);
            response.Data = _mapper.Map<ProductoDetail>(deletedProducto);

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

    [HttpGet("{id:int}/entradas")]
    public async Task<ActionResult<ResponseModel<IEnumerable<EntradaDetail>>>> GetProductoEntradasById(int id)
    {
        var response = new ResponseModel<IEnumerable<EntradaDetail>>();
        try
        {
            var entradas = await _productoServices.GetProductoEntradasById(id);
            response.Data = _mapper.Map<IEnumerable<EntradaDetail>>(entradas);

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

    [HttpGet("{id:int}/salidas")]
    public async Task<ActionResult<ResponseModel<IEnumerable<SalidaDetail>>>> GetProductoSalidasById(int id)
    {
        var response = new ResponseModel<IEnumerable<SalidaDetail>>();
        try
        {
            var salidas = await _productoServices.GetProductoSalidasById(id);
            response.Data = _mapper.Map<IEnumerable<SalidaDetail>>(salidas);

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