<template>
  <div class="home">

    <navbar></navbar>
    
    <div class="main">
      Home
    </div>

  </div>

</template>

<script>
    import Navbar from '../Navbar'
  export default {
    name: 'Home',
    components: {
      'navbar': Navbar
    },
    props: [],
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {

    }
  }
</script>

<style scoped>

</style>