<script setup>
  import Header from '../components/Header.vue';
  import { useFetch } from '../assets/javascript/fetchNewComics';
  const writers = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}`);
</script>

<template>
  <Header></Header>
  <div class="constainer pt-5">
    <div class="row pt-5">
      <div class="col-md-12 pt-5">
        <p v-for="writer in writers" :key="writer.id">
          {{writer.name}}
        </p>
      </div>
    </div>
  </div>
</template>