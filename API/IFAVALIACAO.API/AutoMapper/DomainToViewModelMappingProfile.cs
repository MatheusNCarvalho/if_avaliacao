using AutoMapper;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Fazenda, FazendaModel>();
            CreateMap<Vaca, VacaModel>();
        }
    }
}