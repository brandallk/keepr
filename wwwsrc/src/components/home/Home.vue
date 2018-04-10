<template>
  <div class="home">

    <navbar v-on:menuOptionChange="changeHomeBody"></navbar>
    
    <div class="home-body">

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
        homeBody: 'my-keeps'
      }
    },
    computed: {
      myKeeps() {
        return this.$store.state.myKeeps
      }
    },
    methods: {
      changeHomeBody(value) {
        this.homeBody = value
      }
    }
  }
</script>

<style scoped>

</style>