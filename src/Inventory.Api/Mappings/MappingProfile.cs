using AutoMapper;
using Inventory.Core.DTOs.Entradas;
using Inventory.Core.DTOs.Productos;
using Inventory.Core.DTOs.Razones;
using Inventory.Core.DTOs.Salidas;
using Inventory.Core.DTOs.Unidades;
using Inventory.Core.DTOs.Usuarios;
using Inventory.Core.Entities;

namespace Inventory.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioLogin, Usuario>();
        CreateMap<UsuarioRegister, Usuario>();
        CreateMap<Usuario, UsuarioTokenDetail>();
        CreateMap<Usuario, UsuarioDetail>();

        CreateMap<UnidadAdd, Unidad>();
        CreateMap<UnidadEdit, Unidad>();
        CreateMap<Unidad, UnidadDetail>();

        CreateMap<RazonAdd, Razon>();
        CreateMap<RazonEdit, Razon>();
        CreateMap<Razon, RazonDetail>();

        CreateMap<ProductoAdd, Producto>();
        CreateMap<ProductoEdit, Producto>();
        CreateMap<Producto, ProductoDetail>();
        CreateMap<Producto, EntradaSalidaProductoDetail>();

        CreateMap<EntradaAdd, Entrada>();
        CreateMap<EntradaEdit, Entrada>();
        CreateMap<Entrada, EntradaDetail>();

        CreateMap<SalidaAdd, Salida>();
        CreateMap<Salida, SalidaDetail>();
    }
}
