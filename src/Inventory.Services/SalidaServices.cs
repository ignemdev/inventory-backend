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

public class SalidaServices : ISalidaServices
{
    private readonly IUnitOfWork _unitOfWork;
    public SalidaServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Salida> AddSalida(Salida salida)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(salida, new ValidationContext(salida), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (salida == null)
            throw new ArgumentNullException(Messages.E003);

        var addedSalida = await _unitOfWork.Salidas.AddAsync(salida);

        var producto = await _unitOfWork.Productos.GetByIdAsync(addedSalida.ProductoId);
       
        var stockMenorQueSalida = producto.Stock < addedSalida.Cantidad;

        if (stockMenorQueSalida)
            throw new InvalidOperationException(Messages.E006);

        await _unitOfWork.Productos.UpdateStockAsync(addedSalida.ProductoId, addedSalida.Cantidad * -1);

        await _unitOfWork.SaveAsync();

        return addedSalida;
    }

    public async Task<IEnumerable<Salida>> GetAllSalidas()
    {
        var salidas = await _unitOfWork.Salidas.GetAllAsync(includeProperties: "Creador,Modificador,Producto,Razon",
            orderBy: s => s.OrderByDescending(x => x.Creado));

        return salidas;
    }

    public async Task<Salida> GetSalidaById(int salidaId)
    {
        if (salidaId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbSalida = await _unitOfWork.Salidas.GetFirstOrDefaultAsync(s => s.Id == salidaId,
            includeProperties: "Creador,Modificador,Producto,Razon");

        if (dbSalida == null)
            throw new NullReferenceException(Messages.E005);

        return dbSalida;
    }
}

