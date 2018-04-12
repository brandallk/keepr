<template>
    <div class="share-options-dropdown pt-0">
  
      <div class="form-group">
        <select class="form-control" name="share-option-select" v-model="selectedOption" @change="selectOption" @click.stop="noop">
          <option value="" disabled selected>choose</option>
          <option value="facebook">Facebook</option>
          <option value="twitter">Twitter</option>
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
          console.log('share via this.selectedOption:', this.selectedOption)
          if (this.selectedOption === "facebook") {
            window.open('//www.facebook.com/sharer/sharer.php?u=' + this.keep.link, 'facebook-popup', 'height=350,width=600')
          }
          if (this.selectedOption === "twitter") {
            window.open('//twitter.com/share?url=' + this.keep.link, 'twitter-popup', 'height=350,width=600')
          }
          this.keep.shareCount++
          this.$store.dispatch('updateKeep', this.keep)
          // need to .then $emit to do this.showShareOptionsDropdown=false on KeepCard.vue parent
          this.$emit('closeShareOptionsDropdown')
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