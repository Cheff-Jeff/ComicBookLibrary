<script setup>
  import { useRoute } from 'vue-router';
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import ComicDetail from '@/components/ComicDetail.vue';
  import BannerRight from '@/components/BannerRight.vue';
  import { addItem } from '@/assets/javascript/library'
  import { ComicHub } from '@/assets/javascript/SignalR';

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
      @AddComic="addComic(comic.id)"
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      hub: null
    }
  },
  mounted() {
    this.hub = new ComicHub()
  },
  methods: {
    async addComic(id) {
      if(sessionStorage.getItem('user')){
        let result = await addItem(id)
        console.log(result)
        this.hub.addNewPopularity(id)
      }
    }
  },
}
</script>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>