using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringDev.INegocio.Negocios;
using HiringDev.Util.Enun;
using HiringDev.Util.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HiringDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        private readonly IBuscarVideosYouTubeNegocio _buscaVideo;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="buscaVideo"></param>
        public YouTubeController(IOptions<AppSettings> appSettings, IBuscarVideosYouTubeNegocio buscaVideo)
        {
            _buscaVideo = buscaVideo;
        }

        // GET api/values/5
        [HttpGet("{busca}")]
        public async Task<IActionResult> Get(string busca)
        {
            var videos = await _buscaVideo.BuscarAsync(busca);

            return Ok(new
            {
                success = true,
                videos = videos.Where(v => v.Tipo == TipoVideo.Video).ToList(),
                canais = videos.Where(v => v.Tipo == TipoVideo.Canal).ToList()
            });
        }
    }
}