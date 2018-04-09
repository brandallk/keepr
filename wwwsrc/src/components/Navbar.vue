<template>

  <div class="navbar p-0">

    <div class="title-bar w-100 p-4 border-bottom border-primary">
  
      <div class="container-fluid d-flex align-content-center">
        <img class="logo" src="../assets/logo.svg" alt="keepr logo" v-if="!sessionUser">
        <span class="h3 mb-0" v-if="sessionUser">{{sessionUser}}'s Dashboard</span>
  
        <button class="btn btn-primary ml-auto" v-if="!sessionUser" @click="openRegisterModal">register</button>
  
        <button class="btn btn-primary ml-2" v-if="!sessionUser" @click="openLoginModal">log in</button>
  
        <button class="btn btn-danger ml-auto" v-if="sessionUser" @click="logout">log out</button>
      </div>
        
    </div>

    <div class="menu-bar row w-100 mx-0" v-if="sessionUser">
      <div class="menu-option col-12 col-md-3 p-3 text-center text-white" :class="{ selected: selectedMenuOption == 'my-keeps' }" @click="dataSelectedMenuOption = 'my-keeps'">
        My Keeps
      </div>
      <div class="menu-option col-12 col-md-3 p-3 text-center text-white" :class="{ selected: selectedMenuOption == 'new-keep' }" @click="dataSelectedMenuOption = 'new-keep'">
        New Keep
      </div>
      <div class="menu-option col-12 col-md-3 p-3 text-center text-white" :class="{ selected: selectedMenuOption == 'my-vaults' }" @click="dataSelectedMenuOption = 'my-vaults'">
        My Vaults
      </div>
      <div class="menu-option col-12 col-md-3 p-3 text-center text-white" :class="{ selected: selectedMenuOption == 'new-vault' }" @click="dataSelectedMenuOption = 'new-vault'">
        New Vault
      </div>
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
      'login-modal': LoginModal,
    },
    props: [],
    data() {
      return {
        showRegisterModal: false,
        showLoginModal: false,
        dataSelectedMenuOption: 'my-keeps'
      }
    },
    watch: {
      dataSelectedMenuOption() {
        this.$emit('menuOptionChange', this.dataSelectedMenuOption)
      }
    },
    computed: {
      sessionUser() {
        return this.$store.state.user.username
      },
      selectedMenuOption() {
        return this.dataSelectedMenuOption
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
  .logo {
    height: 2.3rem;
  }
  .menu-option {
    background-color: dodgerblue;
  }
  .menu-option:hover {
    background-color: rgba(30, 143, 255, 0.6);
    cursor: pointer;
  }
  .menu-option.selected {
    background-color: rgba(30, 143, 255, 0.7);
    cursor: pointer;
  }
</style>