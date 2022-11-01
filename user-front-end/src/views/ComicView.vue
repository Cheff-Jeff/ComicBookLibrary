<script setup>
  import { useRoute } from 'vue-router';
  import { useFetch } from '../assets/javascript/fetchNewComics';
  import ComicDetail from '../components/ComicDetail.vue';
  import BannerRight from '../components/BannerRight.vue';

  const route = useRoute();
  const comic = useFetch(`${import.meta.env.VITE_API_COMICS_URL}/${route.params.slug}`);
  
  defineExpose({comic});
</script>

<template>
  <div v-if="comic">
    <BannerRight  
      :Title="comic.title"
      :Heading="true"
    />
    <ComicDetail 
      :Title="comic.title"
      :Descriptin="comic.description"
      :Publisher="comic.publisher.name"
      :Image="comic.image"
      :Writer="comic.writer.name"
      :Artist="comic.artist.name"
      :Cover-artist="comic.coverArtist.name"
    />
  </div>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>