using Inventory.Core;
using Inventory.Core.Entities;
using Inventory.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services;

public class ProductoServices : IProductoServices
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductoServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Producto> AddProducto(Producto producto)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(producto, new ValidationContext(producto), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (producto == null)
            throw new ArgumentNullException(Messages.E003);

        var addedProducto = await _unitOfWork.Productos.AddAsync(producto);
        await _unitOfWork.SaveAsync();

        return addedProducto;
    }

    public async Task<Producto> DeleteProductoById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbProducto = await _unitOfWork.Productos.GetByIdAsync(productoId);

        if (dbProducto == null)
            throw new NullReferenceException(Messages.E005);

        _unitOfWork.Productos.RemoveById(productoId);
        await _unitOfWork.SaveAsync();

        return dbProducto;
    }

    public async Task<IEnumerable<Producto>> GetAllProductos()
    {
        var productos = await _unitOfWork.Productos.GetAllAsync(includeProperties:"Creador,Modificador,Unidad",
            orderBy: p => p.OrderByDescending(x => x.Creado));

        return productos;
    }

    public async Task<Producto> GetProductoById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbProducto = await _unitOfWork.Productos.GetFirstOrDefaultAsync(p => p.Id == productoId, 
            includeProperties: "Creador,Modificador,Unidad");

        if (dbProducto == null)
            throw new NullReferenceException(Messages.E005);

        return dbProducto;
    }

    public async Task<IEnumerable<Entrada>> GetProductoEntradasById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(Messages.E004);

        var entradas = await _unitOfWork.Entradas.GetAllAsync(e => e.ProductoId == productoId,
            includeProperties: "Creador,Modificador,Producto",
            orderBy: e => e.OrderByDescending(x => x.Creado));

        return entradas;
    }

    public async Task<IEnumerable<Salida>> GetProductoSalidasById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(Messages.E004);

        var salidas = await _unitOfWork.Salidas.GetAllAsync(s => s.ProductoId == productoId,
            includeProperties: "Creador,Modificador,Producto,Razon",
            orderBy: e => e.OrderByDescending(x => x.Creado));

        return salidas;
    }

    public async Task<Producto> UpdateProducto(Producto producto)
    {
        if (producto == null)
            throw new ArgumentNullException(Messages.E003);

        if (producto.Id == 0)
            throw new ArgumentNullException(Messages.E004);

        var updatedProducto = await _unitOfWork.Productos.UpdateAsync(producto);

        if (updatedProducto == null)
            throw new NullReferenceException(Messages.E005);

        await _unitOfWork.SaveAsync();

        return updatedProducto;
    }
}
