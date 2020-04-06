<template>
    <div class="form-group" id="app">
      <img alt="YouTube  logo" class="img" src="./assets/youtube.png" />
      <YouTube msg="Bem-vindo ao seu buscador YouTube" />
    </div>   
</template>

<script>
import YouTube from "./components/YouTube/YouTube.vue";

export default {
  name: "App",
  components: {
    YouTube
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.img {
  width: 150px;
}
</style>
