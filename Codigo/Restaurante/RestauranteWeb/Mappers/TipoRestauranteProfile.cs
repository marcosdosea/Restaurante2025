using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class TipoRestauranteProfile : Profile
    {
        public TipoRestauranteProfile()
        {
            CreateMap<TipoRestauranteModel, Tiporestaurante>().ReverseMap();
        }
    }
}