using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Core.Funcionario, Models.FuncionarioModel>().ReverseMap();
        }
    }
}
