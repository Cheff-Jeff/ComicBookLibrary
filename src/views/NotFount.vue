<script setup>
  import BannerRight from '../components/BannerRight.vue';
  import { RouterLink } from 'vue-router';
</script>

<template>
  <BannerRight 
    Title="404 Page not found."
  />
  <section class="error404">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-9">
          <img src="@/assets/images/404.png">
          <div class="text-wrap">
            <p class="text-center">You broke something!</p>
            <p class="text-center">Just kidding...</p>
            <p class="text-center">Check that you typed the address correctly or go 
              <RouterLink :to="{name: 'home'}" class="link">
                <span>Home</span>
              </RouterLink>.
            </p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  //@import "@/assets/styles/pages/Home.scss";
</style>