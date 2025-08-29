using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class RestauranteProfile : Profile
    {
        public RestauranteProfile()
        {
            CreateMap<RestauranteModel, Restaurante>()
                .ForMember(dest => dest.IdTipoRestauranteNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.Funcionarios, opt => opt.Ignore())
                .ForMember(dest => dest.Itemcardapios, opt => opt.Ignore())
                .ForMember(dest => dest.Mesas, opt => opt.Ignore());

            CreateMap<Restaurante, RestauranteModel>()
                .ForMember(dest => dest.TipoRestauranteNome,
                    opt => opt.MapFrom(src => src.IdTipoRestauranteNavigation != null ? src.IdTipoRestauranteNavigation.Nome : string.Empty));
        }
    }
}