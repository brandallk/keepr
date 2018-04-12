<template>
  <div class="search-bar">
    <div class="p-3 d-flex justify-content-center">
  
      <form class="form-inline" @submit.prevent="submit">
        <div class="form-group">
          <label for="search">Search: </label>
          <input type="text" class="ml-2" name="search" v-model="searchQuery">
        </div>
        <button type="submit" class="btn btn-default btn-sm ml-2">search</button>
        <button type="button" class="btn btn-default btn-sm ml-2" v-if="showingSearchResults" @click="hideSearchResults">back</button>
      </form>
        
    </div>

    <div class="text-center" v-if="showingSearchResults">
      <p>Search Results:</p>
    </div>

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
        searchQuery: "",
        showingSearchResults: false
      }
    },
    computed: {

    },
    methods: {
      submit() {
        this.$store.dispatch('searchKeeps', this.searchQuery)
        this.searchQuery = ""
        this.showingSearchResults = true
      },
      hideSearchResults() {
        this.$store.dispatch('getPublicKeeps')
        this.showingSearchResults = false
      }
    }
  }
</script>

<style scoped>
  input {
    min-width: 300px;
  }
</style>