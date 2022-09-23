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

  const img = new URL(`/src/assets/images/comics/${Image}`, import.meta.url)
</script>

<template>
  <div class="comic">
    <a href="#">
      <img :src="img" alt="Comic book cover">
      <p>{{ Title }}</p>
    </a>
  </div>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>