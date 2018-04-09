import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import authStore from './auth-store'
import router from '../router'

var production = !window.location.host.includes('localhost')
var baseUrl = production ? '//localhost:5000/' : '//localhost:5000/'

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
    },
    publicKeeps: [
      {
        Id: 1001,
        Name: 'The Wave',
        Description: 'Rippling sand dunes frozen in the Arizona rock.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzLzRhYjgwOTc5NzExZTQ4YTQwZF9EQ18yMDE0MDUxNF82OTUuanBnIl0sWyJwIiwidGh1bWIiLCJ4MzkwPiJdLFsicCIsImNvbnZlcnQiLCItcXVhbGl0eSA4MSAtYXV0by1vcmllbnQiXV0',
        Link: 'https://www.atlasobscura.com/places/wave-rock',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      },
      {
        Id: 1002,
        Name: 'What Makes a Tree a Tree?',
        Description: 'In Knowable Magazine, Rachel Ehrenberg writes about the tricky business of understanding what a tree is.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://kottke.org/plus/misc/images/broccoli-tree-vandal-00.jpg',
        Link: 'https://kottke.org/18/04/what-makes-a-tree-a-tree-scientists-still-arent-sure',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      },
      {
        Id: 1003,
        Name: 'Unknown Soviet photographer',
        Description: 'Masha Ivashintsova was a photographer based in Leningrad who, when she died in 2000, left over 30,000 photographs.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://kottke.org/plus/misc/images/masha-ivashintsova-01.jpg',
        Link: 'https://kottke.org/18/04/unknown-soviet-photographer-left-a-huge-cache-of-photos-behind-when-she-died',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      },
      {
        Id: 1004,
        Name: 'Earth’s Wonders Like You’ve Never Seen',
        Description: 'Here’s a series of experimental, off-angle images that capture some of the world’s most stunning vertical features.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://cdn-images-1.medium.com/max/938/1*J3p50_aaRwdb9k14e1I3Mg.jpeg',
        Link: 'https://medium.com/planet-stories/earths-wonders-like-you-ve-never-seen-them-before-ac9e2f39aa56',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      },
      {
        Id: 1005,
        Name: 'The Missing Building Blocks of the Web',
        Description: 'At a time when millions are losing trust in the the web’s biggest sites, it’s worth revisiting the idea that the web was supposed to be made out of countless little sites.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://cdn-images-1.medium.com/max/1875/1*sEBZhVAtFEzYS6RJWeC1xA.jpeg',
        Link: 'https://medium.com/@anildash/the-missing-building-blocks-of-the-web-3fa490ae5cbc',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      },
      {
        Id: 1006,
        Name: 'Espresso Coffee Soda',
        Description: 'A dark soda with a dark history.',
        UserId: '80f175b5-20f6-421f-a45e-e2360084f929',
        ImageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvdGhpbmdfaW1hZ2VzLzQ4NjdjMmU0LWY5YjgtNDJiZi05M2Q0LTAwODY0YTE0NWM1NjA2OWJkZGRjNmQyZThjOGJhYV9lc3ByZXNzbyBjb2ZmZWUgc29kYS5qcGciXSxbInAiLCJjb252ZXJ0IiwiLXF1YWxpdHkgODEgLWF1dG8tb3JpZW50Il0sWyJwIiwidGh1bWIiLCI1ODB4NTgwIyJdXQ/espresso%20coffee%20soda.jpg',
        Link: 'https://www.atlasobscura.com/foods/espresso-coffee-soda-manhattan-special',
        KeepCount: 0,
        ShareCount: 0,
        ViewCount: 0
      }
    ]
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