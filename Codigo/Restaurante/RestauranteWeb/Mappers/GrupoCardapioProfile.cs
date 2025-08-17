using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class GrupoCardapioProfile : Profile
    {
        public GrupoCardapioProfile()
        {
            CreateMap<GrupoCardapioModel, Grupocardapio>().ReverseMap();
        }
    }
}
