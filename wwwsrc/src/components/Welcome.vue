<template>
  <div class="welcome">

    <navbar></navbar>
    
    <div class="main">
      Welcome
    </div>
  
  </div>

</template>

<script>
  import Navbar from './Navbar'
  export default {
    name: 'Welcome',
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