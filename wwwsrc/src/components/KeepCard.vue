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
        <div class="overlay-icon keep-icon row">
          <i class="fas fa-eye fa-2x col-12"></i>
          <span class="col-12 text-center">view</span>
        </div>
      </a>
      <div class="overlay-icon keep-icon row" @click="addKeep">
        <i class="fas fa-check-circle fa-2x col-12"></i>
        <span class="col-12 text-center">keep</span>
      </div>
      <div class="overlay-icon keep-icon row" @click="shareKeep">
        <i class="fas fa-share fa-2x col-12"></i>
        <span class="col-12 text-center">share</span>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'KeepCard',
    components: {

    },
    props: [ 'keep' ],
    data() {
      return {
        showOverlay: false
      }
    },
    computed: {

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
      },
      addKeep() {
        console.log(`Add keep ${this.keep.name}`)
        // Increment keep's keepCount
      },
      shareKeep() {
        console.log(`Share keep ${this.keep.name}`)
        // Increment keep's shareCount
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
    background-color: rgba(0, 0, 0, 0.4);
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
    color: white;
  }
  .overlay-icon:hover {
    cursor: pointer;
    color: rgba(255, 255, 255, 0.75);
  }
  a:hover {
    text-decoration: none;
  }
</style>