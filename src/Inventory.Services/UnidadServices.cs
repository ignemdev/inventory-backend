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

public class UnidadServices : IUnidadServices
{
    private readonly IUnitOfWork _unitOfWork;
    public UnidadServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unidad> AddUnidad(Unidad unidad)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(unidad, new ValidationContext(unidad), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (unidad == null)
            throw new ArgumentNullException(Messages.E003);

        var addedUnidad = await _unitOfWork.Unidades.AddAsync(unidad);
        await _unitOfWork.SaveAsync();

        return addedUnidad;
    }

    public async Task<IEnumerable<Unidad>> GetAllUnidades()
    {
        var unidades = await _unitOfWork.Unidades.GetAllAsync(orderBy: u => u.OrderByDescending(x => x.Creado));
        return unidades;
    }

    public async Task<Unidad> GetUnidadById(int unidadId)
    {
        if (unidadId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbUnidad = await _unitOfWork.Unidades.GetByIdAsync(unidadId);

        if (dbUnidad == null)
            throw new NullReferenceException(Messages.E005);

        return dbUnidad;
    }

    public async Task<Unidad> UpdateUnidad(Unidad unidad)
    {
        if (unidad == null)
            throw new ArgumentNullException(Messages.E003);

        if (unidad.Id == 0)
            throw new ArgumentNullException(Messages.E004);

        var updatedUnidad = await _unitOfWork.Unidades.UpdateAsync(unidad);

        if (updatedUnidad == null)
            throw new NullReferenceException(Messages.E005);

        await _unitOfWork.SaveAsync();

        return updatedUnidad;
    }
}
