<template>
  <div class="create-keep-form d-flex justify-content-center">

    <form class="border mt-4" @submit.prevent="submit">
      <h5 class="text-center">Create a New Keep</h5>
      <div class="form-group">
        <label for="name">Name: </label>
        <input type="text" class="form-control" name="name" v-model="form.Name" required>
      </div>
      <div class="form-group">
        <label for="description">Description: </label>
        <input type="text" class="form-control" name="description" v-model="form.Description" required>
      </div>
      <div class="form-group">
        <label for="imageUrl">Image URL: </label>
        <input type="text" class="form-control" name="imageUrl" v-model="form.ImageUrl" required>
      </div>
      <div class="form-group">
        <label for="link">Link: </label>
        <input type="text" class="form-control" name="link" v-model="form.Link" required>
      </div>
      <div class="form-group">
        <label for="tags">Tags: </label>
        <input type="text" class="form-control" name="tags" v-model="tags">
      </div>
      <div class="form-group">
        <label for="public">Set Access to "Public"? </label>
        <input class="ml-2" type="checkbox" name="public" v-model="form.Public">
      </div>
      <button type="button" class="cancel btn btn-default" @click="cancel">cancel</button>
      <button type="submit" class="submit btn btn-primary">submit</button>
    </form>

  </div>

</template>

<script>
  export default {
    name: 'CreateKeepForm',
    components: {

    },
    props: [],
    data() {
      return {
        form: {
          Name: "",
          Description: "",
          ImageUrl: "",
          Link: "",
          Public: false
        },
        tags: ""
      }
    },
    computed: {

    },
    methods: {
      submit() {
        var formData = this.form
        formData.UserId = this.$store.state.user.id
        formData.Public = this.form.Public === false ? 0 : 1
        formData.KeepCount = 0
        formData.ShareCount = 0
        formData.ViewCount = 0

        if (this.tags) {
          var tags = this.tags.replace(/(\s)*/g, "").split(",")
          formData.tags = tags
        }

        this.$store.dispatch('createKeep', formData)

        this.cancel()
      },
      cancel() {
        this.form = {
          Name: "",
          Description: "",
          ImageUrl: "",
          Link: "",
          Public: false
        }
        this.tags = ""
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