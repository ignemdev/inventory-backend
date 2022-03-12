using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models;

public class ResponseModel<TModel>
{
    public TModel Data { get; set; } = default!;
    public string ErrorMessage { get; private set; } = null!;
    public bool HasError { get; set; }
    public void SetErrorMessage(string message)
    {
        ErrorMessage = message;
        HasError = true;
    }
}
