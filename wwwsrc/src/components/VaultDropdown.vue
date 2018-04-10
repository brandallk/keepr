<template>
  <div class="vault-dropdown pt-0">

    <div class="form-group">
      <label class="d-block text-center" for="vault-select" v-if="showDropdownLabel">Choose a vault: </label>
      <select class="form-control" name="vault-select" v-model="selectedVault" @change="selectVault" @click.stop="noop">
        <option disabled selected :value="selectedVault">{{selectedVault.name}}</option>
        <option v-for="vault in vaults" :key="vault.id" :value="vault">{{vault.name}}</option>
      </select>
    </div>

  </div>

</template>

<script>
  export default {
    name: 'VaultDropdown',
    components: {
      
    },
    props: [
      'vaults',
      'showDropdownLabel'
    ],
    data() {
      return {
        selectedVault: { name: 'choose' }
      }
    },
    computed: {

    },
    methods: {
      noop(){},
      selectVault() {
        this.$emit('selectVault', this.selectedVault)
      }
    }
  }
</script>

<style scoped>
  .form-group {
    width: 8rem;
    background-color: white;
    border-radius: 4px;
  }
</style>