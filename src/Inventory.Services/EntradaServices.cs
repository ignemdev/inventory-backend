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

public class EntradaServices : IEntradaServices
{
    private readonly IUnitOfWork _unitOfWork;
    public EntradaServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Entrada> AddEntrada(Entrada entrada)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(entrada, new ValidationContext(entrada), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (entrada == null)
            throw new ArgumentNullException(Messages.E003);

        var addedEntrada = await _unitOfWork.Entradas.AddAsync(entrada);
        await _unitOfWork.Productos.UpdateStockAsync(addedEntrada.ProductoId, addedEntrada.Cantidad);

        await _unitOfWork.SaveAsync();

        return addedEntrada;
    }

    public async Task<Entrada> DeleteEntradaById(int entradaId)
    {
        if (entradaId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbEntrada = await _unitOfWork.Entradas.GetByIdAsync(entradaId);

        if (dbEntrada == null)
            throw new NullReferenceException(Messages.E005);

        _unitOfWork.Entradas.RemoveById(entradaId);
        await _unitOfWork.Productos.UpdateStockAsync(dbEntrada.ProductoId, dbEntrada.Cantidad*-1);

        await _unitOfWork.SaveAsync();

        return dbEntrada;
    }

    public async Task<IEnumerable<Entrada>> GetAllEntradas()
    {
        var entradas = await _unitOfWork.Entradas.GetAllAsync(includeProperties: "Creador,Modificador,Producto",
            orderBy: e => e.OrderByDescending(x => x.Creado));

        return entradas;
    }

    public async Task<Entrada> GetEntradaById(int entradaId)
    {
        if (entradaId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbEntrada = await _unitOfWork.Entradas.GetFirstOrDefaultAsync(e => e.Id == entradaId,
            includeProperties: "Creador,Modificador,Producto");

        if (dbEntrada == null)
            throw new NullReferenceException(Messages.E005);

        return dbEntrada;
    }

    public async Task<Entrada> UpdateEntrada(Entrada entrada)
    {
        if (entrada == null)
            throw new ArgumentNullException(Messages.E003);

        if (entrada.Id == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbEntrada = await _unitOfWork.Entradas.GetByIdAsync(entrada.Id);
        var cantidadAnterior = dbEntrada?.Cantidad ?? 0;

        var updatedEntrada = await _unitOfWork.Entradas.UpdateAsync(entrada);

        if (updatedEntrada == null || dbEntrada == null)
            throw new NullReferenceException(Messages.E005);

        var stock = cantidadAnterior - updatedEntrada.Cantidad;//revisar
        await _unitOfWork.Productos.UpdateStockAsync(dbEntrada.ProductoId, stock*-1);

        await _unitOfWork.SaveAsync();

        return updatedEntrada;
    }
}
