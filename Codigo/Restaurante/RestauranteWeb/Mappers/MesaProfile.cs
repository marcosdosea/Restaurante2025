using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            CreateMap<Core.Mesa, Models.MesaModel>()
                .ForMember(dest => dest.Identificacao, opt => opt.MapFrom(src => src.Identificacao))
                .ForMember(dest => dest.IdRestaurante, opt => opt.MapFrom(src => src.IdRestaurante))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Capacidade, opt => opt.MapFrom(src => src.Capacidade))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ReverseMap();
        }
    }
}
