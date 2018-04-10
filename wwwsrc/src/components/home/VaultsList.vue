<template>
  <div class="vaults-list">
    
    <div class="select d-flex justify-content-center">

      <div class="form-group w-50 mt-4">
        <label class="d-block text-center" for="vault-select">Choose a vault: </label>
        <select class="form-control" name="vault-select" v-model="selectedVault" @change="vaultSelected">
          <option disabled selected :value="selectedVault">{{selectedVault.name}}</option>
          <option v-for="vault in myVaults" :key="vault.id" :value="vault">{{vault.name}}</option>
        </select>
      </div>

    </div>

    <keeps-wall :keeps="keepsInActiveVault"></keeps-wall>

  </div>

</template>

<script>
  import KeepsWall from '../KeepsWall'
  export default {
    name: 'VaultsList',
    components: {
      'keeps-wall': KeepsWall
    },
    props: [],
    data() {
      return {
        selectedVault: { name: 'choose' }
      }
    },
    computed: {
      myVaults() {
        return this.$store.state.myVaults
      },
      keepsInActiveVault() {
        return this.$store.state.keepsInActiveVault
      }
    },
    methods: {
      vaultSelected() {
        console.log('vault selected')
        // Use this.selectedVault to dispatch an action to update this.$store.state.keepsInActiveVault
      }
    }
  }
</script>

<style scoped>

</style>