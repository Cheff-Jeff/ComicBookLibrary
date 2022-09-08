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
  })
</script>

<template>
  <div class="comic">
    <a href="#">
      <img :src="'/src/assets/images/comics/'+ Image" alt="Comic book cover">
      <p>{{ Title }}</p>
    </a>
  </div>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>