using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiringDev.API.Controllers;
using HiringDev.Dominio.ViewModel;
using HiringDev.INegocio.Negocios;
using HiringDev.Negocio.Negocio;
using HiringDev.Util.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace HiringDev.Teste
{
    [TestClass]
    public class YouTubeTeste : ControllerBase
    {
       
        [TestMethod]
        public async Task TestBusca()
        {
            var pesquisa = "Segfy";

            var mock = new Mock<IBuscarVideosYouTubeNegocio>();
            mock.Setup(x => x.BuscarAsync(pesquisa)).ReturnsAsync(new List<BuscaVideosViewModel>());
            
            Assert.IsNotNull(await mock.Object.BuscarAsync(pesquisa));
        }
    }
}
