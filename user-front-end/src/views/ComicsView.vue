<script setup>
import BannerRight from '../components/BannerRight.vue';
import ComicMaster from '../components/ComicMaster.vue';
import { useFetch } from '../assets/javascript/fetchNewComics';
const comics = useFetch(`${import.meta.env.VITE_API_COMICS_URL}?Size=30`);
</script>

<template>
  <BannerRight 
    Title="Browse comics."
    :Heading="true"
  />
  <section class="comics">
    <div class="container lesser">
      <div class="row">
        <div class="col-md-3">
          <!-- filter gaat hier-->
        </div>
        <div class="col-md-9">
          <div class="row">
            <div class="col-md-3 smaller" v-for="comic in comics" :key="comic.id">
              <ComicMaster 
              :Title="comic.title"
              :Link="comic.id"
              :Image="comic.image"/>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Comics.scss";
</style>