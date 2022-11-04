using AutoMapper;

namespace Beca.ViviendaInfo.API.Profiles
{
    public class ViviendaProfile : Profile
    {
        public ViviendaProfile()
        {
            CreateMap<Entities.Vivienda, Models.ViviendaSinReservasDto>();
            CreateMap<Entities.Vivienda, Models.ViviendaDto>();
        }
    }
}
