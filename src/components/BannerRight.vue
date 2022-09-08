<script setup>
  defineProps({
    Title: {
      type: String,
      required: true
    }
  })
</script>

<template>
  <section class="banner">
    <div class="text-wrap">
      <h1>{{ Title }}</h1>
    </div>
    <div class="img-wrap">
      <img src="@/assets/images/secBanner.png" alt="banner">
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/Banner.scss";
</style>