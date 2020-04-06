import Vue from 'vue'
import App from './App.vue'
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import VueLoading from 'vuejs-loading-plugin'

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(VueLoading)

Vue.use(VueLoading, {
  dark: true, // default false
  text: 'Carregando...', // default 'Loading'
  loading: true, // default false
  background: 'rgb(255,255,255)', // set custom background
  classes: ['myclass'] // array, object or string
});

new Vue({
  render: h => h(App),
}).$mount('#app')

