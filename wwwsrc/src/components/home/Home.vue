<template>
  <div class="home">

    <navbar v-on:menuOptionChange="changeHomeBody"></navbar>
    
    <div class="home-body">

      <div class="settings-toggle px-5 py-3 d-flex" v-if="homeBody == 'my-keeps'" :keeps="myKeeps">
        <span class="h5" v-if="showPrivateKeeps">My private keeps:</span>
        <span class="h5" v-if="!showPrivateKeeps">My public keeps:</span>
        <div class="toggles d-inline-block ml-auto">
          <button class="set-public btn btn-primary" v-if="showPrivateKeeps" @click="showPrivateKeeps = false">see public keeps</button>
          <button class="set-private btn btn-primary" v-if="!showPrivateKeeps" @click="showPrivateKeeps = true">see private keeps</button>
        </div>
      </div>

      <keeps-wall v-if="homeBody == 'my-keeps'" :keeps="myKeeps"></keeps-wall>

      <create-keep-form v-if="homeBody == 'new-keep'"></create-keep-form>

      <vaults-list v-if="homeBody == 'my-vaults'"></vaults-list>

      <create-vault-form v-if="homeBody == 'new-vault'"></create-vault-form>

    </div>

  </div>

</template>

<script>
  import Navbar from '../Navbar'
  import KeepsWall from '../KeepsWall'
  import CreateKeepForm from './CreateKeepForm'
  import VaultsList from './VaultsList'
  import CreateVaultForm from './CreateVaultForm'
  export default {
    name: 'Home',
    components: {
      'navbar': Navbar,
      'keeps-wall': KeepsWall,
      'create-keep-form': CreateKeepForm,
      'vaults-list': VaultsList,
      'create-vault-form': CreateVaultForm
    },
    mounted() {
      waitForSessionUser(this) // Wait briefly to make sure the session user has a defined value...
      .then(userId => { // ...then get the user's keeps
        this.$store.dispatch('getMyKeeps', userId)
      })
      function waitForSessionUser(ctx) {
        return new Promise((resolve, reject) => {
          waitForData(ctx)
          function waitForData(ctx) {
            setTimeout(() => {
              if (ctx.$store.state.user.id) {
                resolve(ctx.$store.state.user.id)
              }
              else {
                waitForData(ctx)
              }
            }, 50)
          }
        })
      }
    },
    props: [],
    data() {
      return {
        homeBody: 'my-keeps',
        showPrivateKeeps: false
      }
    },
    computed: {
      myKeeps() {
        return this.showPrivateKeeps ? this.myPrivateKeeps : this.myPublicKeeps
      },
      myPrivateKeeps() {
        return this.$store.state.myKeeps.filter(keep => {
          return keep.public === 1
        })
      },
      myPublicKeeps() {
        return this.$store.state.myKeeps.filter(keep => {
          return keep.public === 0
        })
      }
    },
    methods: {
      changeHomeBody(value) {
        this.homeBody = value
        this.$store.dispatch('clearKeepsInActiveVault')
      }
    }
  }
</script>

<style scoped>

</style>