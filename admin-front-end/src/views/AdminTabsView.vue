<script setup>
  import { RouterLink } from 'vue-router';
  import Header from '../components/Header.vue';
</script>

<template>
  <Header></Header>
  <main>
    <section class="tabs pt-5">
      <div class="btn-wrap pt-5">
        <RouterLink :to="{name: 'addWriters'}">
          <span>Add writers</span>
        </RouterLink><br>
        <RouterLink :to="{name: 'addArtist'}">
          <span>Add artists</span>
        </RouterLink><br>
        <RouterLink :to="{name: 'addPublichers'}">
          <span>Add publichers</span>
        </RouterLink>
        <!-- <RouterLink>
          View all comics
        </RouterLink>
        <RouterLink>
          View all users
        </RouterLink> -->
      </div>
    </section>
  </main>
</template>

<style>

</style>