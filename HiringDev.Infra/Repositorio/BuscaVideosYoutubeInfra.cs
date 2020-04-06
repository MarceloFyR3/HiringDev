using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiringDev.Dominio.Model;
using HiringDev.Infra.Base;
using HiringDev.Infra.Contexto;
using HiringDev.IRepositorio.Repositorio;
using HiringDev.Util.Settings;
using Microsoft.Extensions.Options;

namespace HiringDev.Infra.Repositorio
{
    public class BuscaVideosYoutubeInfra : BaseRepositorio<BuscaVideos>, IBuscaVideosYoutubeRepositorio
    {
        public List<BuscaVideos> InsertMany(List<BuscaVideos> videos)
        {
            _ctx.AddRange(videos);
            _ctx.SaveChanges();

            return videos;
        }
    }
}
