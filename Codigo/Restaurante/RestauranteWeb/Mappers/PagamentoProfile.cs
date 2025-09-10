using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<Core.Pagamento, Models.PagamentoModel>().ReverseMap();
        }
    }
}
