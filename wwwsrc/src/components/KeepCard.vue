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

      <div class="update-icon" v-if="allowEdits">
        <a href="#" class="text-light" @click.prevent="showKeepEditForm = true" title="Edit">
            <i class="fas fa-edit fa-2x"></i>
        </a>
      </div>

      <div class="delete-icon" v-if="allowDeletesFromVault">
        <a href="#" class="text-danger" @click.prevent="removeKeepFromVault" title="Remove from vault">
          <i class="fas fa-times-circle fa-2x"></i>
        </a>
      </div>

      <div class="delete-icon" v-if="!keep.public && !allowDeletesFromVault">
        <a href="#" class="text-danger" @click.prevent="deleteKeep" title="Delete keep">
          <i class="fas fa-times-circle fa-2x"></i>
        </a>
      </div>

      <a :href="keep.link" @click="viewKeep">
        <div class="overlay-icon view-icon row">
          <i class="fas fa-eye fa-2x col-12"></i>
          <span class="col-12 text-center">view</span>
        </div>
      </a>

      <div class="overlay-icon keep-icon row" v-if="sessionUser" @click="toggleVaultDropdown">
        <i class="fas fa-check-circle fa-2x col-12"></i>
        <span class="col-12 text-center">save to vault</span>

        <div class="vault-dropdown" v-if="showVaultDropdown">
          <vault-dropdown :vaults="myVaults" :showDropdownLabel="false" v-on:selectVault="saveKeepToVault"></vault-dropdown>
        </div>

      </div>

      <div class="overlay-icon share-icon row" @click="shareKeep">
        <i class="fas fa-share fa-2x col-12"></i>
        <span class="col-12 text-center">share</span>

        <div class="share-options-dropdown" v-if="showShareOptionsDropdown">
          <share-options-dropdown :keep="keep"></share-options-dropdown>
        </div>

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

    <keep-edit-form v-if="showKeepEditForm" :keep="keep" v-on:closeKeepEditForm="showKeepEditForm = false"></keep-edit-form>

  </div>
</template>

<script>
  import VaultDropdown from './VaultDropdown'
  import ShareOptionsDropdown from './ShareOptionsDropdown'
  import KeepEditForm from './KeepEditForm'
  export default {
    name: 'KeepCard',
    components: {
      'vault-dropdown': VaultDropdown,
      'share-options-dropdown': ShareOptionsDropdown,
      'keep-edit-form': KeepEditForm
    },
    props: [
      'keep',
      'allowEdits',
      'allowDeletesFromVault'
    ],
    data() {
      return {
        showOverlay: false,
        showVaultDropdown: false,
        showKeepEditForm: false,
        showShareOptionsDropdown: false
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
      // tags() {
      //   // Get the tags belonging to this keep
      // },
      activateOverlay() {
        this.showOverlay = true
      },
      deactivateOverlay() {
        this.showOverlay = false
      },
      viewKeep() {
        this.keep.viewCount++
        this.$store.dispatch('updateKeep', this.keep)
      },
      toggleShareOptionsDropdown() {
        this.showShareOptionsDropdown = this.showShareOptionsDropdown ? false : true
        if (this.showVaultDropdown) {
          this.showVaultDropdown = false
        }
      },
      shareKeep() {
        this.toggleShareOptionsDropdown()
      },
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.keep)
      },
      toggleVaultDropdown() {
        this.showVaultDropdown = this.showVaultDropdown ? false : true
        if (this.showShareOptionsDropdown) {
          this.showShareOptionsDropdown = false
        }
      },
      saveKeepToVault(vault) {
        var Ids = {
          VaultId: vault.id,
          KeepId: this.keep.id,
          UserId: this.$store.state.user.id
        }
        this.keep.keepCount++
        this.$store.dispatch('saveKeepToVault', Ids)
      },
      removeKeepFromVault() {
        var data = {
          vault: this.$store.state.activeVault,
          keep: this.keep
        }
        this.$store.dispatch('removeKeepFromVault', data)
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

  .keep-icon,
  .share-icon {
    position: relative;
  }
  .vault-dropdown {
    z-index: 1;
    position: absolute;
    left: 10%;
    bottom: -110%;
  }
  .share-options-dropdown {
    z-index: 1;
    position: absolute;
    left: -10%;
    bottom: -110%;
  }

  .update-icon {
    position: absolute;
    top: 5%;
    left: 5%;
  }

  .delete-icon {
    position: absolute;
    top: 5%;
    right: 5%;
  }
</style>