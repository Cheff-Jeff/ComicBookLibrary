<script setup>
  import { useRoute } from 'vue-router';
  import { useFetch } from '../assets/javascript/fetchNewComics';
  import ComicDetail from '../components/ComicDetail.vue';
  import BannerRight from '../components/BannerRight.vue';

  const route = useRoute();
  const comic = useFetch(`https://webshop.cheffjeff.online/wordpress/wp-json/wp/v2/products?slug=${route.params.slug}`);
  
  defineExpose({comic});
</script>

<template>
  <div v-if="comic">
    <BannerRight  
      :Title="comic[0].title.rendered"
      :Heading="true"
    />
    <ComicDetail 
      :Title="comic[0].title.rendered"
      :Descriptin="comic[0].content.rendered"
    />
  </div>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicMaster.scss";
</style>