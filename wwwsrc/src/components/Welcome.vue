<template>
  <div class="welcome">

    <navbar></navbar>
    
    <div class="main p-4">
      Welcome
    </div>

    <div class="keeps-wrapper container-fluid mx-0 p-4">
        <div class="card-columns">
            <keep-card class="p-2 card" v-for="keep in publicKeeps" :keep="keep" :key="keep.Id"></keep-card>
        </div>
    </div>
  
  </div>

</template>

<script>
  import Navbar from './Navbar'
  import KeepCard from './KeepCard'
  export default {
    name: 'Welcome',
    components: {
      'navbar': Navbar,
      'keep-card': KeepCard
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