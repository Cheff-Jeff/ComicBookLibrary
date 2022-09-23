<script setup>
  defineProps({
    Title: {
      type: String,
      required: true
    },
    Heading: {
      type: Boolean,
      default: true,
      required: true,
    }
  })
</script>

<template>
  <section class="banner">
    <div class="img-wrap">
      <img src="@/assets/images/corner.png" alt="banner">
    </div>
    <div class="text-wrap">
      <h1 v-if="Heading">{{ Title }}</h1>
      <h2 v-else="Heading">{{ Title }}</h2>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/BannerLeft.scss";
</style>