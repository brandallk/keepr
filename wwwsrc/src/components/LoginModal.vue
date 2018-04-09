<template>
  <div class="background">
    <div class="login-modal container">
  
      <form @submit.prevent="submit">
        <h5 class="text-center">Log In</h5>
        <div class="form-group">
          <label for="email">Email: </label>
          <input type="email" class="form-control" name="email" v-model="form.Email" required>
        </div>
        <div class="form-group">
          <label for="password">Password: </label>
          <input type="password" class="form-control" name="password" v-model="form.Password" required>
        </div>
        <button type="button" class="cancel btn btn-default" @click="cancel">cancel</button>
        <button type="submit" class="submit btn btn-primary">submit</button>
      </form>
  
    </div>
  </div>
</template>

<script>
  export default {
    name: 'LoginModal',
    components: {

    },
    props: [],
    data() {
      return {
        form: {
          Email: 'me@mymail.com',
          Password: '**********'
        }
      }
    },
    computed: {
      formDefaults() {
        return this.form.Email === 'me@mymail.com' || this.form.Password === '**********'
      }
    },
    methods: {
      cancel() {
        this.$emit('closeLoginModal')
      },
      submit() {
        if (!this.formDefaults) {
          console.log('this.form', this.form)
          this.$store.dispatch('login', this.form)
          this.$emit('closeLoginModal')
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
  .login-modal {
    width: 95%;
    background-color: white;
    padding: 2rem;
    border-radius: 4px;
  }
  @media (min-width: 576px) {
    .login-modal {
      width: 50%;
    }
  }
</style>