using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class FormaPagamentoProfile : Profile
    {
        public FormaPagamentoProfile()
        {
            CreateMap<Formapagamento, FormaPagamentoModel>().ReverseMap();
        }


    }
}
