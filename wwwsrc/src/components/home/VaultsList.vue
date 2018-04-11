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

    <div class="vault-description text-center">
      <p>{{selectedVault.description}}</p>
    </div>

    <div class="vault-options text-center" v-if="selectedVault.name !== 'choose'">
      <button class="btn btn-default btn-sm" @click="loadVaultEditForm">edit this vault</button>
      <button class="btn btn-danger btn-sm ml-2" @click="deleteVault">delete this vault</button>
    </div>

    <edit-vault-form v-if="showVaultEditForm" :vault="selectedVault" v-on:closeEditVaultForm="showVaultEditForm = false"></edit-vault-form>

    <keeps-wall :keeps="keepsInActiveVault" :allowDeletesFromVault="true"></keeps-wall>

  </div>

</template>

<script>
  import KeepsWall from '../KeepsWall'
  import EditVaultForm from './EditVaultForm'
  export default {
    name: 'VaultsList',
    components: {
      'keeps-wall': KeepsWall,
      'edit-vault-form': EditVaultForm
    },
    props: [],
    data() {
      return {
        selectedVault: { name: 'choose' },
        showVaultEditForm: false
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
        this.$store.dispatch('getKeepsForVault', this.selectedVault)
      },
      loadVaultEditForm() {
        this.selectedVault = this.selectedVault
        this.showVaultEditForm = true
      },
      deleteVault() {
        this.$store.dispatch('deleteVault', this.selectedVault)
        this.selectedVault = { name: 'choose' }
      }
    }
  }
</script>

<style scoped>

</style>