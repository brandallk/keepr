<template>
  <div class="keep-card" @mouseover="activateOverlay" @mouseout="deactivateOverlay">
    
    <div class="card">
      <img class="card-img-top" :src="keep.imageUrl" :alt="keep.name">
      <div class="card-body">
        <h5 class="card-title">{{ keep.name }}</h5>
        <p class="card-text">{{ keep.description }}</p>
      </div>
    </div>

    <div class="overlay" v-if="showOverlay">

      <a :href="keep.link" @click="viewKeep">
        <div class="overlay-icon view-icon row">
          <i class="fas fa-eye fa-2x col-12"></i>
          <span class="col-12 text-center">view</span>
        </div>
      </a>

      <div class="overlay-icon keep-icon row" v-if="sessionUser" @click="toggleVaultDropdown">
        <i class="fas fa-check-circle fa-2x col-12"></i>
        <span class="col-12 text-center">save to vault</span>

        <div class="vault-dropdown" v-if="showVaultDropdown" >
          <vault-dropdown :vaults="myVaults" :showDropdownLabel="false" v-on:selectVault="saveKeepToVault"></vault-dropdown>
        </div>

      </div>

      <div class="overlay-icon share-icon row" @click="shareKeep">
        <i class="fas fa-share fa-2x col-12"></i>
        <span class="col-12 text-center">share</span>
      </div>

    </div>

    <div class="stats row px-2 text-muted">
      <div class="col text-center">
        <span><small>views: {{keep.viewCount}}</small></span>
      </div>
      <div class="col text-center">
        <span><small>keeps: {{keep.keepCount}}</small></span>
      </div>
      <div class="col text-center">
        <span><small>shares: {{keep.shareCount}}</small></span>
      </div>
    </div>

  </div>
</template>

<script>
  import VaultDropdown from './VaultDropdown'
  export default {
    name: 'KeepCard',
    components: {
      'vault-dropdown': VaultDropdown
    },
    props: [
      'keep'
    ],
    data() {
      return {
        showOverlay: false,
        showVaultDropdown: false
      }
    },
    computed: {
      sessionUser() {
        return this.$store.state.user.username
      },
      myVaults() {
        return this.$store.state.myVaults
      }
    },
    methods: {
      activateOverlay() {
        this.showOverlay = true
      },
      deactivateOverlay() {
        this.showOverlay = false
      },
      viewKeep() {
        console.log(`View keep ${this.keep.name}`)
        // Increment keep's viewCount
        this.keep.viewCount++
        this.$store.dispatch('updateKeep', this.keep)
      },
      shareKeep() {
        this.keep.shareCount++
        this.$store.dispatch('updateKeep', this.keep)
        // This method will have to change...
        // 1. Show the share-options dropdown
        // 2. The dropdown will have a separate @change method (and @click.stop="noop")
        //   a. The @change will do the incrementing of the keep's shareCount
        //   b. It will also implement the 3rd-party sharing via Facebook or Twitter
      },
      toggleVaultDropdown() {
        this.showVaultDropdown = this.showVaultDropdown ? false : true
      },
      saveKeepToVault(vault) {
        var Ids = {
          VaultId: vault.id,
          KeepId: this.keep.id,
          UserId: this.$store.state.user.id
        }
        this.keep.keepCount++
        this.$store.dispatch('saveKeepToVault', Ids)
      }
    }
  }
</script>

<style scoped>
  .keep-card {
    position: relative;
  }
  .overlay {
    border-radius: 4px;
    background-color: rgba(0, 0, 0, 0.5);
    position: absolute;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .overlay-icon {
    color: rgb(204, 230, 255);
  }
  .overlay-icon:hover {
    cursor: pointer;
    color: rgba(255, 255, 255, 0.75);
  }
  .overlay-icon span {
    margin-top: 0.35rem;
    padding-top: 0.25rem; 
    padding-bottom: 0.25rem; 
    background-color: dodgerblue;
  }
  a:hover {
    text-decoration: none;
  }

  .keep-icon {
    position: relative;
  }
  .vault-dropdown {
    z-index: 1;
    position: absolute;
    left: 10%;
    bottom: -110%;
  }
</style>