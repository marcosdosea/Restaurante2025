using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class TipoFuncionarioProfile : Profile
    {
        public TipoFuncionarioProfile()
        {
            CreateMap<TipoFuncionarioModel, Tipofuncionario>().ReverseMap();
        }

    }
}
