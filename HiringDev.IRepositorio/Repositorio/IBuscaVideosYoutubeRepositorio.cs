using System;
using System.Collections.Generic;
using System.Text;
using HiringDev.Dominio.Model;
using HiringDev.IRepositorio.Base;

namespace HiringDev.IRepositorio.Repositorio
{
    public interface IBuscaVideosYoutubeRepositorio : IBaseRepositorio<BuscaVideos>
    {
        List<BuscaVideos> InsertMany(List<BuscaVideos> videos);
    }
}
