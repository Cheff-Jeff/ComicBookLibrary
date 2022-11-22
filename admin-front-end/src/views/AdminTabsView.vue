<script setup>
  import { RouterLink } from 'vue-router';
  import Header from '../components/Header.vue';
</script>

<template>
  <Header></Header>
  <main>
    <section class="tabs">
      <div class="container">
        <div class="row">
          <div class="col-md-6">
            <p>
              <RouterLink :to="{name: 'addWriters'}" class="link">
                <span>Add writers</span>
              </RouterLink>
            </p>
          </div>
          <div class="col-md-6">
            <p>
              <RouterLink :to="{name: 'addArtist'}" class="link">
                <span>Add artists</span>
              </RouterLink>
            </p>
          </div>
          <div class="col-md-6">
            <p>
              <RouterLink :to="{name: 'addPublichers'}" class="link">
                <span>Add publichers</span>
              </RouterLink>
            </p>
          </div>
          <div class="col-md-6">
            <p>
              <RouterLink :to="{name: 'addComics'}" class="link">
                <span>Add comics</span>
              </RouterLink>
            </p>
          </div>
        </div>
      </div>
    </section>
  </main>
</template>

<style lang="scss" scoped>
@import "../assets/styles/pages/Home.scss";
</style>