<template>
  <div class="welcome">

    <navbar></navbar>

    <search-bar></search-bar>

    <keeps-wall :keeps="publicKeeps"></keeps-wall>
  
  </div>

</template>

<script>
  import Navbar from './Navbar'
  import SearchBar from './SearchBar'
  import KeepsWall from './KeepsWall'
  export default {
    name: 'Welcome',
    components: {
      'navbar': Navbar,
      'search-bar': SearchBar,
      'keeps-wall': KeepsWall
    },
    mounted() {
      this.$store.dispatch('getPublicKeeps')
    },
    props: [],
    data() {
      return {

      }
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      }
    },
    methods: {

    }
  }
</script>

<style scoped>

</style>