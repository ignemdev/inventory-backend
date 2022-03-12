using AutoMapper;
using Inventory.Core.DTOs.Usuarios;
using Inventory.Core.Entities;

namespace Inventory.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioLoginRequest, Usuario>();
        CreateMap<UsuarioRegisterRequest, Usuario>();
        CreateMap<Usuario, UsuarioResponse>();
    }
}
