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
        id: 1001,
        name: 'The Wave',
        description: 'Rippling sand dunes frozen in the Arizona rock.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzLzRhYjgwOTc5NzExZTQ4YTQwZF9EQ18yMDE0MDUxNF82OTUuanBnIl0sWyJwIiwidGh1bWIiLCJ4MzkwPiJdLFsicCIsImNvbnZlcnQiLCItcXVhbGl0eSA4MSAtYXV0by1vcmllbnQiXV0',
        link: 'https://www.atlasobscura.com/places/wave-rock',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1002,
        name: 'What Makes a Tree a Tree?',
        description: 'In Knowable Magazine, Rachel Ehrenberg writes about the tricky business of understanding what a tree is.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://kottke.org/plus/misc/images/broccoli-tree-vandal-00.jpg',
        link: 'https://kottke.org/18/04/what-makes-a-tree-a-tree-scientists-still-arent-sure',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1003,
        name: 'Unknown Soviet photographer',
        description: 'Masha Ivashintsova was a photographer based in Leningrad who, when she died in 2000, left over 30,000 photographs.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://kottke.org/plus/misc/images/masha-ivashintsova-01.jpg',
        Link: 'https://kottke.org/18/04/unknown-soviet-photographer-left-a-huge-cache-of-photos-behind-when-she-died',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1004,
        name: 'Earth’s Wonders Like You’ve Never Seen',
        description: 'Here’s a series of experimental, off-angle images that capture some of the world’s most stunning vertical features.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://cdn-images-1.medium.com/max/938/1*J3p50_aaRwdb9k14e1I3Mg.jpeg',
        link: 'https://medium.com/planet-stories/earths-wonders-like-you-ve-never-seen-them-before-ac9e2f39aa56',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1005,
        name: 'The Missing Building Blocks of the Web',
        description: 'At a time when millions are losing trust in the the web’s biggest sites, it’s worth revisiting the idea that the web was supposed to be made out of countless little sites.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://cdn-images-1.medium.com/max/1875/1*sEBZhVAtFEzYS6RJWeC1xA.jpeg',
        link: 'https://medium.com/@anildash/the-missing-building-blocks-of-the-web-3fa490ae5cbc',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1006,
        name: 'Espresso Coffee Soda',
        description: 'A dark soda with a dark history.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvdGhpbmdfaW1hZ2VzLzQ4NjdjMmU0LWY5YjgtNDJiZi05M2Q0LTAwODY0YTE0NWM1NjA2OWJkZGRjNmQyZThjOGJhYV9lc3ByZXNzbyBjb2ZmZWUgc29kYS5qcGciXSxbInAiLCJjb252ZXJ0IiwiLXF1YWxpdHkgODEgLWF1dG8tb3JpZW50Il0sWyJwIiwidGh1bWIiLCI1ODB4NTgwIyJdXQ/espresso%20coffee%20soda.jpg',
        link: 'https://www.atlasobscura.com/foods/espresso-coffee-soda-manhattan-special',
        public: 1,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      }
    ],
    myKeeps: [
      {
        id: 1007,
        name: 'Rakotzbrücke Devil\'s Bridge',
        description: 'This jaw-dropping 19th-century bridge uses its reflection to form a perfect circle.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzLzU0MThjOTY4MTExNzRhZDhkNl8yNTI1OTY2MzIzNF82YzExNTM3YWYyX2suanBnIl0sWyJwIiwidGh1bWIiLCJ4MzkwPiJdLFsicCIsImNvbnZlcnQiLCItcXVhbGl0eSA4MSAtYXV0by1vcmllbnQiXV0/25259663234_6c11537af2_k.jpg',
        link: 'https://www.atlasobscura.com/places/rakotzbrucke-devils-bridge',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1008,
        name: 'Sagano Bamboo Forest',
        description: 'The sound of swaying stalks in this stunning grove has been voted to be a governmentally recognized sound.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL2U2ZTI3NTAzOTM3ODU1OTAwYl80MDcwNTgxNzA5XzEyMDRmMjVlM2JfYi5qcGciXSxbInAiLCJ0aHVtYiIsIngzOTA-Il0sWyJwIiwiY29udmVydCIsIi1xdWFsaXR5IDgxIC1hdXRvLW9yaWVudCJdXQ/e6e27503937855900b_4070581709_1204f25e3b_b.jpg',
        link: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL2U2ZTI3NTAzOTM3ODU1OTAwYl80MDcwNTgxNzA5XzEyMDRmMjVlM2JfYi5qcGciXSxbInAiLCJ0aHVtYiIsIngzOTA-Il0sWyJwIiwiY29udmVydCIsIi1xdWFsaXR5IDgxIC1hdXRvLW9yaWVudCJdXQ/e6e27503937855900b_4070581709_1204f25e3b_b.jpg',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1009,
        name: 'Leadenhall Market',
        description: 'This ornate Victorian marketplace was the setting for Diagon Alley and the Leaky Cauldron in the Harry Potter films.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL2E2ZGY5ZjM5ODc0YzljNTMzNF8xMjAwcHgtTGVhZGVuaGFsbF9NYXJrZXRfSW5fTG9uZG9uXy1fRmViXzIwMDZfcm90YXRlZC5qcGciXSxbInAiLCJ0aHVtYiIsIngzOTA-Il0sWyJwIiwiY29udmVydCIsIi1xdWFsaXR5IDgxIC1hdXRvLW9yaWVudCJdXQ/1200px-Leadenhall_Market_In_London_-_Feb_2006_rotated.jpg',
        link: 'https://www.atlasobscura.com/places/leadenhall-market',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1010,
        name: 'The Ruins of St. Dunstan-in-the-East',
        description: 'One of the few remaining casualties of the London Blitz, this destroyed church has become an enchanting public garden.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL2JmYzkwOGVjNjVkMjEyN2M1Ml9JTUdfMDU2NS5KUEciXSxbInAiLCJ0aHVtYiIsIngzOTA-Il0sWyJwIiwiY29udmVydCIsIi1xdWFsaXR5IDgxIC1hdXRvLW9yaWVudCJdXQ',
        link: 'https://www.atlasobscura.com/places/the-ruins-of-st-dunstan-in-the-east',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1011,
        name: 'Horseshoe Bend',
        description: 'Dramatic river bend surrounds a natural red-rocked pedestal.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzLzZlMmNjNDhmNWYzYTk2YmE2ZmY1M2ViNzlkMGM1OWRmN2M3MmRiYmYuanBnIl0sWyJwIiwidGh1bWIiLCJ4MzkwPiJdLFsicCIsImNvbnZlcnQiLCItcXVhbGl0eSA4MSAtYXV0by1vcmllbnQiXV0/6e2cc48f5f3a96ba6ff53eb79d0c59df7c72dbbf.jpg',
        link: 'https://www.atlasobscura.com/places/horseshoe-bend',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
      },
      {
        id: 1012,
        name: 'Museum of Neon Art',
        description: 'A one-of-a-kind collection of a unique medium.',
        userId: '80f175b5-20f6-421f-a45e-e2360084f929',
        imageUrl: 'https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL25lb24xLmpwZyJdLFsicCIsInRodW1iIiwieDM5MD4iXSxbInAiLCJjb252ZXJ0IiwiLXF1YWxpdHkgODEgLWF1dG8tb3JpZW50Il1d/neon1.jpg',
        link: 'https://www.atlasobscura.com/places/museum-neon-art-g',
        public: 0,
        keepCount: 0,
        shareCount: 0,
        viewCount: 0
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
    },
    addToMyKeeps(state, keep) {
      state.myKeeps.push(keep)
    }
  },

  actions: {

    createKeep({commit, dispatch}, formData) {
      var tags = []
      if (formData.tags) {
        tags = formData.tags
        delete formData.tags // 'tags' do not appear in 'keep' model
      }
      api.post('keeps', formData)
      .then(res => {
        console.log('post new keep res', res)
        var newKeep = res.data
        console.log('new keep', newKeep)
        commit('addToMyKeeps', newKeep)

        tags.forEach(tag => {
          var keepTag = {}
          // determine if the tag already exists
          api.get(`tags/${tag}`) // Get tag by name
          .then(res => {
            var existingTag = res.data
            console.log('existingTag', existingTag)
            // if it doesn't, create a new tag
            if (!existingTag) {
              console.log('tag', tag)
              api.post('tags', { Name: tag })
              .then(res => {
                var newTag = res.data
                keepTag = { KeepId: newKeep.id, TagId: newTag.id }
                // either way, create a new keeptags for the relationship
                api.post('keeptags', keepTag)
                .then(res => {
                  var newKeepTag = res.data
                  console.log('newKeepTag', newKeepTag)
                })
                .catch(err => { console.log(err) })
              })
              .catch(err => { console.log(err) })
            }
            else {
              keepTag = { KeepId: newKeep.id, TagId: existingTag.id }
              // either way, create a new keeptags for the relationship
              api.post('keeptags', keepTag)
              .then(res => {
                var newKeepTag = res.data
                console.log('newKeepTag', newKeepTag)
              })
              .catch(err => { console.log(err) })
            }
          })
          .catch(err => { console.log(err) })
        })
      })
      .catch(err => {
        console.log(err)
      })
    }

  }

})

export default store