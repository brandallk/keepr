import axios from 'axios'
import router from '../router'

var production = !window.location.host.includes('localhost')
var baseUrl = production ? '//localhost:5000/' : '//localhost:5000/'

var auth = axios.create({
  baseURL: baseUrl + 'Account/',
  timeout: 3000,
  withCredentials: true
})

export default {
  actions: {
    register({commit, dispatch}, formData) {
      auth.post('register', formData)
      .then(res => {
        var newUser = res.data
        console.log('Registered a new user:', newUser)
        commit('setUser', newUser)
        commit('setAuthError', {error: false, message: ''})
        router.push({name: 'Home'})
      })
      .catch(err => {
        console.log(err)
        commit('setAuthError', {
          error: true,
          message: "Register attempt failed: Invalid username, email, or password"
        })
      })
    },

    login({commit, dispatch}, formData) {
      auth.post('login', formData)
      .then(res => {
        var user = res.data
        console.log('User logged in:', user.username)
        commit('setUser', user)
        commit('setAuthError', {error: false, message: ''})
        router.push({name: 'Home'})
      })
      .catch(err => {
        console.log(err)
        commit('setAuthError', {
          error: true,
          message: 'Login attempt failed: Invalid email or password'
        })
      })
    },

    authenticate({commit, dispatch}) {
      auth.get('authenticate')
      .then(res => {
        if (res.data) {
          var returningUser = res.data
          console.log('User returned to session:', returningUser)
          commit('setUser', returningUser)
          commit('setAuthError', {error: false, message: ''})
          router.push({name: 'Home'})
        }
        else {
          console.log('Could not authenticate user')
        }
      })
      .catch(() => {
        console.log('Session authentication failed')
      })
    },

    logout({commit, dispatch}) {
      auth.delete('logout')
      .then(res => {
        console.log(res.data)
        commit('setUser', {})
        commit('setAuthError', {error: false, message: ''})
        router.push({name: 'Welcome'})
      })
      .catch(err => {
        console.log(err)
      })
    },

    updateAccount({commit, dispatch}, formData) {
      auth.put('')
      .then(res => {
        var updatedUser = res.data
        commit('setUser', updatedUser)
      })
      .catch(err => {
        console.log(err)
      })
    },

    updatePassword({commit, dispatch}, formData) {
      auth.put('password-update')
      .then(res => {
        console.log(res.data)
      })
      .catch(err => {
        console.log(err)
      })
    }
  }
}