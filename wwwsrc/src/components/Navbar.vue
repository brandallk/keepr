<template>
  <div class="navbar p-4 border-bottom border-dark">

    <div class="container-fluid">
      <button class="btn btn-primary ml-auto" v-if="!sessionUser" @click="openRegisterModal">register</button>

      <button class="btn btn-primary ml-2" v-if="!sessionUser" @click="openLoginModal">log in</button>

      <button class="btn btn-danger ml-auto" v-if="sessionUser" @click="logout">log out</button>
    </div>

    <register-modal v-if="showRegisterModal" v-on:closeRegisterModal="showRegisterModal = false"></register-modal>

    <login-modal v-if="showLoginModal" v-on:closeLoginModal="showLoginModal = false"></login-modal>

  </div>

</template>

<script>
  import RegisterModal from './RegisterModal'
  import LoginModal from './LoginModal'
  export default {
    name: 'Navbar',
    components: {
      'register-modal': RegisterModal,
      'login-modal': LoginModal
    },
    props: [],
    data() {
      return {
        showRegisterModal: false,
        showLoginModal: false
      }
    },
    computed: {
      sessionUser() {
        return this.$store.state.user.username
      }
    },
    methods: {
      openRegisterModal() {
        this.showRegisterModal = true
      },
      openLoginModal() {
        this.showLoginModal = true
      },
      logout() {
        if (this.sessionUser) {
          this.$store.dispatch('logout')
        }
      }
    }
  }
</script>

<style scoped>

</style>