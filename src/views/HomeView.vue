<script setup>
import BannerRight from '../components/BannerRight.vue';
import BannerLeft from '../components/BannerLeft.vue';
</script>

<template>
  <BannerLeft Title="What’s new this week?" />
  <BannerRight 
    Title="Test" 
    v-bind:Heading="false" 
    class="black"
  />
</template>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Home.scss";
</style>