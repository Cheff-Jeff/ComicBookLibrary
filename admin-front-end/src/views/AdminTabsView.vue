<script setup>
  import { RouterLink } from 'vue-router';
  import Header from '../components/Header.vue';
</script>

<template>
  <Header></Header>
  <main>
    <section class="tabs">
      <div class="btn-wrap">
        <RouterLink>
          View all comics
        </RouterLink>
        <RouterLink>
          View all users
        </RouterLink>
      </div>
    </section>
  </main>
</template>

<style>

</style>