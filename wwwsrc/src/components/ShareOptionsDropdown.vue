<template>
    <div class="share-options-dropdown pt-0">
  
      <div class="form-group">
        <select class="form-control" name="share-option-select" v-model="selectedOption" @change="selectOption" @click.stop="noop">
          <option value="" disabled selected>choose</option>
          <option>Facebook</option>
          <option>Twitter</option>
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
          if (this.selectedOption === 'Facebook') {
            // share via facebook
          }
          else if (this.selectedOption === 'Twitter') {
            // share via Twitter
          }
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
  </style>