<script setup>
  import BannerRight from '@/components/BannerRight.vue';
  import BannerLeft from '@/components/BannerLeft.vue';
  import ComicMaster from '@/components/ComicMaster.vue';
  import { useCache, useFetch } from '@/assets/javascript/fetchNewComics';
  import { ComicHub } from '@/assets/javascript/SignalR';

  const newComics = useFetch(`${import.meta.env.VITE_API_COMICS_URL}?Size=5`);
  const popComics = useFetch(`${import.meta.env.VITE_API_COMICS_URL}?Size=10`);
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
              :Title="comic.title"
              :key="comic.id"
              :Link="comic.id"
              :Image="comic.image"
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
            <ComicMaster :Title="comic.title.rendered" :Link="comic.id" :Image="comic.image"/>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      hub: null,
      popularComics: null
    }
  },
  mounted() {
    this.hub = new ComicHub()
    window.addEventListener('PopularComics', ()=>{
      console.log(localStorage.getItem('popular'))
      localStorage.removeItem('popular')
    })
    console.log(this.popComics);
  },
  methods: {
    setComics(comics){
      this.popularComics = null
      this.popularComics = comics
    }
  },
}
</script>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Home.scss";
</style>