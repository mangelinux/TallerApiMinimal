using AutoMapper;
using Sol.TallerNet.ApiVentas.Applications.Dtos.output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Model.Mappers
{
    public class AutoMapperDto: Profile
    {
        public AutoMapperDto()
        {
            CreateMap<Usuario, UserAutenticaOutput>()
                .ForMember(dto => dto.Codigo, map => map.MapFrom(source => source.IdUsuario))
                .ForMember(dto => dto.Credencial, map => map.MapFrom(source => source.Credenciales))
                ;
        }

    }
}
