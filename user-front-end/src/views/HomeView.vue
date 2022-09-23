<script setup>
  import BannerRight from '../components/BannerRight.vue';
  import BannerLeft from '../components/BannerLeft.vue';
  import ComicMaster from '../components/ComicMaster.vue';
  import { useCache } from '../assets/javascript/fetchNewComics';

  const comics = useCache("https://webshop.cheffjeff.online/wordpress/wp-json/wp/v2/products?per_page=10");
</script>

<template>
  <BannerLeft Title="What’s new this week?" />
  <section class="new">
    <div class="container bigger">
      <div class="row">
        <div class="col-md-12">
          <div class="inner">
            <ComicMaster 
              v-for="comic in comics" 
              :Title="comic.title.rendered"
              :key="comic.id"
            />
          </div>
        </div>
      </div>
    </div>
  </section>
  <BannerRight 
    Title="Popular comis this month." 
    v-bind:Heading="false" 
    class="black"
  />
  <section class="popular">
    <div class="container-fluid">
      <div class="row">
        <div 
          class="col-md-3 smaller"
          v-for="comic in comics">
            <ComicMaster :Title="comic.title.rendered" :key="comic.id"/>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Home.scss";
</style>