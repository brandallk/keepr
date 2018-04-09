<template>
  <div class="home">

    <navbar v-on:menuOptionChange="changeHomeBody"></navbar>
    
    <div class="home-body">

      <keeps-wall v-if="homeBody == 'my-keeps'" :keeps="myKeeps"></keeps-wall>

      <create-keep-form v-if="homeBody == 'new-keep'"></create-keep-form>

    </div>

  </div>

</template>

<script>
  import Navbar from '../Navbar'
  import KeepsWall from '../KeepsWall'
  import CreateKeepForm from './CreateKeepForm'
  export default {
    name: 'Home',
    components: {
      'navbar': Navbar,
      'keeps-wall': KeepsWall,
      'create-keep-form': CreateKeepForm
    },
    mounted() {
      this.$store.dispatch('getMyKeeps', this.$store.state.user.id)
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