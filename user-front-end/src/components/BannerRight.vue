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
    <div class="text-wrap">
      <h1 v-if="Heading">{{ Title }}</h1>
      <h2 v-else>{{ Title }}</h2>
    </div>
    <div class="img-wrap">
      <img src="/images/secBanner.png" alt="banner">
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/Banner.scss";
</style>