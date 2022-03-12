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

public class RazonServices : IRazonServices
{
    private readonly IUnitOfWork _unitOfWork;
    public RazonServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Razon> AddRazon(Razon razon)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(razon, new ValidationContext(razon), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (razon == null)
            throw new ArgumentNullException(Messages.E003);

        var addedRazon = await _unitOfWork.Razones.AddAsync(razon);
        await _unitOfWork.SaveAsync();

        return addedRazon;
    }

    public async Task<IEnumerable<Razon>> GetAllRazones()
    {
        var razones = await _unitOfWork.Razones.GetAllAsync(orderBy: r => r.OrderByDescending(x => x.Creado));
        return razones;
    }

    public async Task<Razon> GetRazonById(int razonId)
    {
        if (razonId == 0)
            throw new ArgumentNullException(Messages.E004);

        var dbRazon = await _unitOfWork.Razones.GetByIdAsync(razonId);

        if (dbRazon == null)
            throw new NullReferenceException(Messages.E005);

        return dbRazon;
    }

    public async Task<Razon> UpdateRazon(Razon razon)
    {
        if (razon == null)
            throw new ArgumentNullException(Messages.E003);

        if (razon.Id == 0)
            throw new ArgumentNullException(Messages.E004);

        var updatedRazon = await _unitOfWork.Razones.UpdateAsync(razon);

        if (updatedRazon == null)
            throw new NullReferenceException(Messages.E005);

        await _unitOfWork.SaveAsync();

        return updatedRazon;
    }
}
