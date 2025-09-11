using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoModel, Pedido>()
                .ForMember(dest => dest.IdAtendimentoNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdGarcomNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.Pedidoitemcardapios, opt => opt.Ignore());

            CreateMap<Pedido, PedidoModel>()
                .ForMember(dest => dest.NumeroAtendimento,
                    opt => opt.MapFrom(src => src.IdAtendimentoNavigation != null ?
                                           $"Atendimento #{src.IdAtendimentoNavigation.Id}" : ""))
                .ForMember(dest => dest.NomeGarcom,
                    opt => opt.MapFrom(src => src.IdGarcomNavigation != null ?
                                           src.IdGarcomNavigation.Nome : ""))
                .ForMember(dest => dest.MesaIdentificacao,
                    opt => opt.MapFrom(src => src.IdAtendimentoNavigation != null &&
                                           src.IdAtendimentoNavigation.IdMesaNavigation != null ?
                                           src.IdAtendimentoNavigation.IdMesaNavigation.Identificacao : ""));
        }
    }
}