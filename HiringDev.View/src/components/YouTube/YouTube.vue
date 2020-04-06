<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <p>
      Faça sua busca no campo abaixo.
      <br />
    </p>

    <b-row>
      <div class="col-md-2"></div>

      <div class="col-md-8">
        <b-form v-on:submit.prevent="pesquisaYoutube()">
          <b-input-group class="mt-3">
            <template v-slot:append>
              <b-input-group-text @click="pesquisaYoutube()" class="pointer">
                <strong class="">Pesquisar</strong>
              </b-input-group-text>
            </template>
            <b-form-input v-model="txtPesquisar" placeholder="Pesquisar"></b-form-input>
          </b-input-group>
        </b-form>
      </div>
      <div class="col-md-2"></div>
    </b-row>

    <b-row class="mt-3" v-if="busca">
      <div class="col-md-2"></div>
      <div class="col-md-8">
        <h3 class="left">Canais</h3>
        <hr class="mt-0"/>
        <table class="table table-responsive table-striped table-hover table-dark">
          <tbody>
            <tr v-if="temCanais">             
              <td class="total">Nenhum Canal Encontrado</td>
            </tr>
            <tr @click="irParaovideo(resul.canalId,true)" class="pointer" v-for="resul of canais" :key="resul.idBuscaVideo">
              <td>
                <img class="image image-canal" :src="resul.imagemCapa" />
              </td>
              <td class="position-text">{{ resul.canalTitulo }}</td>
              <td class="position-text parcial60">{{ resul.descricao }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="col-md-2"></div>
    </b-row>

    <b-row class="mt-3" v-if="temVideos">
      <div class="col-md-2"></div>
      <div class="col-md-8">
        <h3 class="left">Vídeos</h3>
        <hr class="mt-0"/>
        <table class="table table-responsive table-striped table-hover table-dark">
          <tbody>
            <tr @click="irParaovideo(resul.videoId,false)" class="pointer" v-for="resul of videos" :key="resul.idBuscaVideo">
              <td>
                <img class="image" :src="resul.imagemCapa" />
              </td>
              <td class="position-text">{{ resul.descricao }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="col-md-2"></div>
    </b-row>
  </div>
</template>

<script src="./YouTube.js"></script>