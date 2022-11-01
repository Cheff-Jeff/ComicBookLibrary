<script setup>
  import { useRoute } from 'vue-router';
  import Header from '@/components/Header.vue';
  import ArtistsForm from '@/components/forms/ArtistsForm.vue';
  import { useFetch } from '@/assets/javascript/fetchNewComics';

  const route = useRoute();
  const artist = useFetch(`${import.meta.env.VITE_API_ARTISTS_URL}/${route.params.id}`);
</script>

<template>
  <Header></Header>
  <div class="container" v-if="artist">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <ArtistsForm 
            @submit='redirect' 
            :Value="artist.name" 
            :Id="artist.id" 
            apiType="put"
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
      this.$router.push({name: 'Artists'});
    }
  }
}
</script>