using System;
using HiringDev.Util.Enun;

namespace HiringDev.Dominio.ViewModel
{
    public class BuscaVideosViewModel
    {
        public int IdBuscaVideo { get; set; }
        public Guid BuscaGuid { get; set; }
        public string ImagemCapa { get; set; }
        public string TermoBusca { get; set; }
        public DateTime DataBusca { get; set; }
        public TipoVideo Tipo { get; set; }
        public string VideoId { get; set; }
        public string CanalId { get; set; }
        public string CanalTitulo { get; set; }
        public string Descricao { get; set; }
        public string Tag { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Titulo { get; set; }
    }
}
