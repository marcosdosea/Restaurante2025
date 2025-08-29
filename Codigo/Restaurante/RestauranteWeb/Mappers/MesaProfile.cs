using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            CreateMap<Core.Mesa, Models.MesaModel>().ReverseMap();
        }
    }
}
