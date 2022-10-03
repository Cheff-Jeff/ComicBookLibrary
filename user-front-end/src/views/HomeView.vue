<script setup>
  import BannerRight from '../components/BannerRight.vue';
  import BannerLeft from '../components/BannerLeft.vue';
  import ComicMaster from '../components/ComicMaster.vue';
  import { useCache, useFetch } from '../assets/javascript/fetchNewComics';

  const newComics = useCache("https://webshop.cheffjeff.online/wordpress/wp-json/wp/v2/products?per_page=5", "newComics");
  const popComics = useCache("https://webshop.cheffjeff.online/wordpress/wp-json/wp/v2/products?per_page=10", "popComics");
</script>

<template>
  <BannerLeft Title="What’s new this week?" />
  <section class="new">
    <div class="container bigger">
      <div class="row">
        <div class="col-md-12">
          <div class="inner" v-if="newComics">
            <ComicMaster 
              v-for="comic in newComics" 
              :Title="comic.title.rendered"
              :key="comic.id"
              Link="alien-3"
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
      <div class="row" v-if="popComics">
        <div 
          class="col-md-3 smaller"
          v-for="comic in popComics"
          :key="comic.id">
            <ComicMaster :Title="comic.title.rendered"/>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Home.scss";
</style>