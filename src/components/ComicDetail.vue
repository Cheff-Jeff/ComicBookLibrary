<script setup>
  defineProps({
    Title: {
      type: String,
      required: true,
      default: "Lorem",
    },
    Descriptin: {
      type: String,
      required: true,
      default: `Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
      sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
      Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris 
      nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in 
      reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla 
      pariatur. Excepteur sint occaecat cupidatat non proident, 
      sunt in culpa qui officia deserunt mollit anim id est laborum.`,
    },
    Image: {
      type: String,
      default: "defaultComic.jpg",
    },
    Publisher: {
      type: String,
      required: true,
      default: "Marvel",
    },
    Writer: {
      type: String,
      required: true,
      default: "Stan Lee",
    },
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