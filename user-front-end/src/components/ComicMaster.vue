<script setup>
  import { RouterLink } from 'vue-router';
  const imgLink = import.meta.env.VITE_IMAGES
  
  defineProps({
    Title: {
      type: String,
      required: true
    },
    Image: {
      type: String,
      default: "defaultComic.jpg",
    },
    Link: {
      type: String,
      required: true,
    }
  });
</script>

<template>
  <div class="comic">
    <a @click="teleport">
      <img :src="`${imgLink}/${Image}`" alt="Comic book cover">
      <p>{{ Title }}</p>
    </a>
  </div>
</template>

<script>
  export default {
    methods: {
      teleport() {
        this.$router.push({ name: 'comicDetail', params: { slug: this.Link } })
      }
    }
  };
</script>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>