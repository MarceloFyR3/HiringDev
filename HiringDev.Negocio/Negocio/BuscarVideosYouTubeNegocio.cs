using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using HiringDev.Dominio.Model;
using HiringDev.Dominio.ViewModel;
using HiringDev.INegocio.Negocios;
using HiringDev.IRepositorio.Repositorio;
using HiringDev.Negocio.Base;
using HiringDev.Util.Enun;
using HiringDev.Util.Settings;
using HiringDev.Util.Utils;
using Microsoft.Extensions.Options;

namespace HiringDev.Negocio.Negocio
{
    public class BuscarVideosYouTubeNegocio : BaseNegocio<BuscaVideosViewModel, BuscaVideos>, IBuscarVideosYouTubeNegocio
    {
        private readonly IMapper _mapper;
        private readonly IBuscaVideosYoutubeRepositorio _repositorio;
        private readonly AppSettings _appSettings;


        public BuscarVideosYouTubeNegocio(IMapper mapper, IBuscaVideosYoutubeRepositorio repositorio, IOptions<AppSettings> appSettings) : base(repositorio, mapper)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _appSettings = appSettings.Value;
        }
        
        public async Task<IList<BuscaVideosViewModel>> BuscarAsync(string busca)
        {
            try
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApplicationName = _appSettings.ApplicationName,//"Hiring",
                    ApiKey = _appSettings.ApiKey//"AIzaSyD7h-uHD6L8SUhIIrhxxy0cLBzBjZ-Xq1E"
                });

                var searchListRequest = youtubeService.Search.List(_appSettings.Parth);
                searchListRequest.Q = busca;
                searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
                searchListRequest.MaxResults = 25;

                var searchListResponse = await searchListRequest.ExecuteAsync();

                var videos = new List<BuscaVideosViewModel>();
                var guidBusca = Guid.NewGuid();

                foreach (var searchResult in searchListResponse.Items)
                {
                    var video = new BuscaVideosViewModel
                    {
                        TermoBusca = busca,
                        BuscaGuid = guidBusca,
                        ImagemCapa = searchResult.Snippet.Thumbnails.Medium.Url,
                        DataBusca = DateTime.Now,
                        VideoId = searchResult.Id.VideoId,
                        CanalId = searchResult.Snippet.ChannelId,
                        CanalTitulo = searchResult.Snippet.ChannelTitle,
                        Descricao = searchResult.Snippet.Description,
                        Tag = searchResult.ETag,
                        DataPublicacao = searchResult.Snippet.PublishedAt,
                        Titulo = searchResult.Snippet.Title,
                        Tipo = Conversores.ParseDescriptionToEnum<TipoVideo>(searchResult.Id.Kind)
                    };

                    videos.Add(video);
                }

                //inserindo no banco e retornando a lista com o id
                return _mapper.Map<List<BuscaVideosViewModel>>(_repositorio.InsertMany(_mapper.Map<List<BuscaVideos>>(videos)));
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
