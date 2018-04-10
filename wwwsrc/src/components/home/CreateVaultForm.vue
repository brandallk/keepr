<template>
  <div class="create-vault-form d-flex justify-content-center">
    
    <form class="border mt-4" @submit.prevent="submit">
      <h5 class="text-center">Create a New Vault</h5>
      <div class="form-group">
        <label for="name">Name </label>
        <input type="text" class="form-control" name="name" v-model="form.Name" required>
      </div>
      <div class="form-group">
        <label for="description">Description: </label>
        <input type="text" class="form-control" name="description" v-model="form.Description" required>
      </div>
      <button type="button" class="cancel btn btn-default" @click="cancel">cancel</button>
      <button type="submit" class="submit btn btn-primary">submit</button>
    </form>

  </div>
</template>

<script>
  export default {
    name: 'CreateVaultForm',
    components: {

    },
    props: [],
    data() {
      return {
        form: {
          Name: "",
          Description: ""
        }
      }
    },
    computed: {

    },
    methods: {
      submit() {
        var formData = this.form
        formData.UserId = this.$store.state.user.id
        this.$store.dispatch('createVault', formData)
        this.cancel()
      },
      cancel() {
        this.form = {
          Name: "",
          Description: ""
        }
      }
    }
  }
</script>

<style scoped>
  form {
    width: 95%;
    background-color: white;
    padding: 2rem;
    border-radius: 4px;
  }
  @media (min-width: 576px) {
    form {
      width: 50%;
    }
  }
</style>