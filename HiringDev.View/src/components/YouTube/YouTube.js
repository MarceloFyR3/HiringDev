import "./YouTube.scss";
import http from "@/_helper/api-services.js";

export default {
  name: 'YouTube',
  data() {
    return {
      videos: [],
      canais: [],
      txtPesquisar: String(),
      temVideos: false,
      temCanais: false,
      busca: false

    }
  },
  props: {
    msg: String
  },
  beforeMount() {

  },
  methods: {
    pesquisaYoutube() {
      this.$loading(true);
      var pesquisa = this.txtPesquisar
      http.get("/Youtube/" + pesquisa).then((response) => {

        if (response.data.success) {
          this.busca = true
          this.videos = response.data.videos
          this.canais = response.data.canais
         
          if (this.videos.length > 0) {
            this.temVideos = true
          }
          else{
            this.temVideos = false
          }

          if (this.canais.length < 1) {
            this.temCanais = true
          }
          else{
            this.temCanais = false
          }
        }
        this.$loading(false);
      });
    },
    irParaovideo(id,canal){

      var rotaCanal = "https://www.youtube.com/channel/";
      var rotaVideo = "https://www.youtube.com/watch?v=";
      if(canal){
        window.open(rotaCanal + id, '_blank');
      }
      else{
        window.open(rotaVideo + id, '_blank');
      }
      
    }
  }
}