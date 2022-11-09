<script setup>
  import { useRoute } from 'vue-router';
  import Header from '@/components/Header.vue';
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import ComicForm from '@/components/forms/ComicForm.vue'

  const route = useRoute();
  const comic = useFetch(`${import.meta.env.VITE_API_COMICS_URL}/${route.params.id}`);
</script>

<template>
  <Header></Header>
  <div class="container" v-if="comic">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <ComicForm 
            @submit='redirect'
            apiType="put"
            :oldId="comic.id"
            :oldTitle="comic.title"
            :oldDescription="comic.description"
            :oldImg="comic.image"
            :oldPublicherId="comic.publisher.id"
            :oldPublicher="comic.publisher.name"
            :oldWriterId="comic.writer.id"
            :oldWriter="comic.writer.name"
            :oldArtistId="comic.artist.id"
            :oldArtist="comic.artist.name"
            :oldCoverArtistId="comic.coverArtist.id"
            :oldCoverArtist="comic.coverArtist.name"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    redirect() {
      this.$router.push({name: 'comics'});
    }
  }
}
</script>

<style>

</style>