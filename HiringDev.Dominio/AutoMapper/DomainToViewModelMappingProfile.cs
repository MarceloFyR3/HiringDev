using AutoMapper;
using HiringDev.Dominio.Model;
using HiringDev.Dominio.ViewModel;

namespace HiringDev.Dominio.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BuscaVideos, BuscaVideosViewModel>();
        }
    }
}
