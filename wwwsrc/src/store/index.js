import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import authStore from './auth-store'
import router from '../router'

var production = !window.location.host.includes('localhost')
var baseUrl = production ? '//localhost:5000/' : 'localhost:5000/'

var api = axios.create({
  baseURL: baseUrl + 'api/',
  timeout: 3000,
  withCredentials: true
})

Vue.use(Vuex)

var store = new Vuex.Store({

  modules: {
    authStore
  },

  state: {
    user: {},
    authError: {
      error: false,
      message: ''
    }
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setAuthError(state, error) {
      state.authError = {
        error: error.error,
        message: error.message
      }
    }
  },

  actions: {

  }

})

export default store