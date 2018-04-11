<template>
  <div class="background">
    <div class="edit-vault-form container">

      <form @submit.prevent="submit">
        <h5 class="text-center">Edit {{vault.name}} Vault</h5>
        <div class="form-group">
          <label for="name">Name: </label>
          <input type="text" class="form-control" name="name" v-model="form.Name">
        </div>
        <div class="form-group">
          <label for="description">Description: </label>
          <input type="text" class="form-control" name="description" v-model="form.Description">
        </div>
        <button type="button" class="cancel btn btn-default" @click="cancel">cancel</button>
        <button type="submit" class="submit btn btn-primary">submit</button>
      </form>

    </div>
  </div>
</template>

<script>
  export default {
    name: 'EditVaultForm',
    components: {

    },
    props: [ 'vault' ],
    data() {
      return {
        form: {
          Name: this.vault.name,
          Description: this.vault.description
        }
      }
    },
    computed: {
      vaultName: {
        get() {
          return this.vault.name
        },
        set(value) {
          this.form.Name = value
        }
      },
      vaultDescription: {
        get() {
          return this.vault.description
        },
        set(value) {
          this.form.Description = value
        }
      },
      formDefaults() {
        return this.form.Name === this.vault.name && this.form.Description === this.vault.description
      }
    },
    methods: {
      cancel() {
        this.$emit('closeEditVaultForm')
      },
      submit() {
        if (!this.formDefaults) {
          this.vault.name = this.form.Name
          this.vault.description = this.form.Description
          this.$store.dispatch('updateVault', this.vault)
          this.cancel()
        }
      }
    }
  }
</script>

<style scoped>
  .background {
    z-index: 1;
    background-color: rgba(0, 0, 0, 0.8);
    position: fixed;
    width: 100%;
    height: 100vh;
    top: 0;
    left: 0;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .edit-vault-form {
    width: 95%;
    background-color: white;
    padding: 2rem;
    border-radius: 4px;
  }
  @media (min-width: 576px) {
    .edit-vault-form {
      width: 50%;
    }
  }
</style>