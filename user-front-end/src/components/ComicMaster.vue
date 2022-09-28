<script setup>
  import { RouterLink } from 'vue-router';

  defineProps({
    Title: {
      type: String,
      required: true
    },

    Image: {
      type: String,
      default: "defaultComic.jpg",
    }
  });
</script>

<template>
  <div class="comic">
    <a href="#">
      <img :src="imgPath" alt="Comic book cover">
      <p>{{ Title }}</p>
    </a>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        imgPath: ''
      }
    },
    mounted() {
      if(this.Image !== null)
      {
        this.imgPath = new URL(`/images/comics/${this.Image}`, import.meta.url).href
      }
      else
      {
        this.imgPath = new URL(`/images/comics/defaultComic.jpg`, import.meta.url).href
      }
    }
  };
</script>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>