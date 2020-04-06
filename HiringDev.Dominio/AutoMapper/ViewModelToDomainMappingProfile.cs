using AutoMapper;
using HiringDev.Dominio.Model;
using HiringDev.Dominio.ViewModel;

namespace HiringDev.Dominio.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BuscaVideosViewModel, BuscaVideos>();
        }
    }
}
