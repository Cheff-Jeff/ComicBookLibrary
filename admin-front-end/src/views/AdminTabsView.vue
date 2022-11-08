<script setup>
  import { RouterLink } from 'vue-router';
  import Header from '../components/Header.vue';
</script>

<template>
  <Header></Header>
  <main>
    <section class="tabs pt-5">
      <div class="btn-wrap pt-5">
        <p><RouterLink :to="{name: 'addWriters'}" class="link">
          <span>Add writers</span>
        </RouterLink></p><br>
        <p><RouterLink :to="{name: 'addArtist'}" class="link">
          <span>Add artists</span>
        </RouterLink></p><br>
        <p><RouterLink :to="{name: 'addPublichers'}" class="link">
          <span>Add publichers</span>
        </RouterLink></p>
      </div>
    </section>
  </main>
</template>

<style>

</style>