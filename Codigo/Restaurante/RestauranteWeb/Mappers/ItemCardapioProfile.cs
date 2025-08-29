using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class ItemCardapioProfile : Profile
    {
        public ItemCardapioProfile()
        {
            CreateMap<Models.ItemCardapioModel, Core.Itemcardapio>().ReverseMap();
        }
    }
}
