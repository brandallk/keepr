<template>
  <div class="background">
    <div class="keep-edit-form container">
  
      <form @submit.prevent="submit">
        <h5 class="text-center">Edit Keep</h5>
        <div class="form-group">
          <label for="name">Name: </label>
          <input type="text" class="form-control" name="name" v-model="form.Name">
        </div>
        <div class="form-group">
          <label for="description">Description: </label>
          <input type="text" class="form-control" name="Description" v-model="form.Description">
        </div>
        <div class="form-group">
          <label for="imageUrl">Image URL: </label>
          <input type="text" class="form-control" name="imageUrl" v-model="form.ImageUrl">
        </div>
        <div class="form-group">
          <label for="link">Link: </label>
          <input type="text" class="form-control" name="link" v-model="form.Link">
        </div>
        <!-- <div class="form-group">
          <label for="tags">Tags: </label>
          <input type="text" class="form-control" name="tags" v-model="tags">
        </div> -->
        <div class="form-group" v-if="!keep.public">
          <label for="public">Public Access Setting: </label>
          <input class="ml-2" type="checkbox" name="public" v-model="form.Public">
        </div>
        <button type="button" class="cancel btn btn-default" @click="cancel">cancel</button>
        <button type="submit" class="submit btn btn-primary">submit</button>
      </form>
  
    </div>
  </div>
</template>

<script>
  export default {
    name: 'KeepEditForm',
    components: {

    },
    props: [
      'keep'
    ],
    data() {
      return {
        form: {
          Name: this.keep.name,
          Description: this.keep.description,
          ImageUrl: this.keep.imageUrl,
          Link: this.keep.link,
          Public: !!(this.keep.public)
        },
        // tags: ""
      }
    },
    computed: {

    },
    methods: {
      submit() {
        var keep = this.keep
        keep.name = this.form.Name
        keep.description = this.form.Description
        keep.imageUrl = this.form.ImageUrl
        keep.link = this.form.Link
        keep.public = this.form.Public ? 1 : 0

        this.$store.dispatch('updateKeep', keep)
        this.cancel()
      },
      cancel() {
        this.$emit('closeKeepEditForm')
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
  .keep-edit-form {
    width: 95%;
    background-color: white;
    padding: 2rem;
    border-radius: 4px;
  }
  @media (min-width: 576px) {
    .keep-edit-form {
      width: 50%;
    }
  }
</style>