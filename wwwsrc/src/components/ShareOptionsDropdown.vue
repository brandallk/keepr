<template>
    <div class="share-options-dropdown pt-0">
  
      <div class="form-group">
        <select class="form-control" name="share-option-select" v-model="selectedOption" @change="selectOption" @click.stop="noop">
          <option value="" disabled selected>choose</option>
          <option :value="'https://www.facebook.com/sharer/sharer.php?u=' + keep.link">Facebook</option>
          <option :value="'https://twitter.com/intent/tweet?url=' + keep.link + '&text=TEXT&via=YOURTWITTERACCOUNTNAME'">Twitter</option>
        </select>
      </div>
  
    </div>
  
  </template>
  
  <script>
    export default {
      name: 'ShareOptionsDropdown',
      components: {
        
      },
      props: [ 'keep' ],
      data() {
        return {
          selectedOption: ""
        }
      },
      computed: {
  
      },
      methods: {
        noop(){},
        selectOption() {
          // IN PROGRESS: Need to diagnose use of the Facebook & Twitter links
          console.log('share via this.selectedOption:', this.selectedOption)
          this.$router.push(this.selectedOption)
          this.keep.shareCount++
          this.$store.dispatch('updateKeep', this.keep)
          // need to .then $emit to do this.showShareOptionsDropdown=false on KeepCard.vue parent
        }
      }
    }
  </script>
  
  <style scoped>
    .form-group {
      width: 8rem;
      background-color: white;
      border-radius: 4px;
    }
    a:hover {
      text-decoration: none;
    }
  </style>