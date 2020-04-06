using System.Collections.Generic;
using System.Threading.Tasks;
using HiringDev.Dominio.Model;
using HiringDev.Dominio.ViewModel;
using HiringDev.INegocio.Base;
using HiringDev.Util.Settings;

namespace HiringDev.INegocio.Negocios
{
    public interface IBuscarVideosYouTubeNegocio : IBaseNegocio<BuscaVideosViewModel, BuscaVideos>
    {
        Task<IList<BuscaVideosViewModel>> BuscarAsync(string busca);
    }
}
