<template>
  <div class="search-bar p-3 d-flex justify-content-center">

    <form class="form-inline" @submit.prevent="submit">
      <div class="form-group">
        <label for="search">Search: </label>
        <input type="text" class="ml-2" name="search" v-model="searchQuery">
      </div>
      <button type="submit" class="btn btn-default btn-sm ml-2">search</button>
    </form>

  </div>
</template>

<script>
  export default {
    name: 'SearchBar',
    components: {

    },
    props: [],
    data() {
      return {
        searchQuery: ""
      }
    },
    computed: {

    },
    methods: {
      submit() {
        this.$store.dispatch('searchKeeps', this.searchQuery)
      }
    }
  }
</script>

<style scoped>
  input {
    min-width: 300px;
  }
</style>