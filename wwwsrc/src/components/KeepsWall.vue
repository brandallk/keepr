<template>
  <div class="keeps-wall">

    <div class="keeps-wrapper container-fluid mx-0 p-4">
      <div class="card-columns">
          <keep-card class="p-2 card" v-for="keep in keeps" :keep="keep" :key="keep.Id" :allowEdits="allowEdits" :allowDeletesFromVault="allowDeletesFromVault"></keep-card>
      </div>
    </div>

  </div>
</template>

<script>
  import KeepCard from './KeepCard'
  export default {
    name: 'KeepsWall',
    components: {
      'keep-card': KeepCard
    },
    props: [
      'keeps',
      'allowEdits',
      'allowDeletesFromVault'
    ],
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