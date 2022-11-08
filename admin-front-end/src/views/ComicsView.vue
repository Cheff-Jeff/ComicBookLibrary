<script setup>
import { RouterLink } from 'vue-router'
import Header from '@/components/Header.vue';
import { useFetch } from '@/assets/javascript/fetchNewComics';
  const comics = useFetch(`${import.meta.env.VITE_API_COMICS_URL}`);
  const imgLink = import.meta.env.VITE_IMAGES
</script>

<template>
  <Header></Header>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <div class="inner mt-5 pt-5">
          <RouterLink :to="{name: 'addComics'}" class="btn btn-primary">
            <span>
              Add Comics
            </span>
          </RouterLink>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-2" v-for="comic in comics" :key="comic.id">
        <img :src="`${imgLink}/${comic.image}`" alt="comic cover">
        <p>{{comic.title}}</p>
        <div class="row">
          <div class="col-md-6">
            <RouterLink :to="{name: 'updateComic', params: { id: comic.id }}">
              <span class="btn btn-primary">
                Edit
              </span>
            </RouterLink>
          </div>
          <div class="col-md-6">
            <button 
              class="btn btn-danger" 
              data-toggle="modal" 
              data-target="#deleteModal"
            >
              <span>Delete</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style>

</style>