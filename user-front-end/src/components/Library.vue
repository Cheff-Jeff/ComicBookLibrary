<script setup>
  import {getUserLibrary} from '@/assets/javascript/library'
  import ComicMaster from '@/components/ComicMaster.vue';
  import {removeItem} from '@/assets/javascript/library'
  const comics = getUserLibrary(sessionStorage.getItem('user'));
</script>

<template>
  <div class="row" v-if="comics">
    <div class="col-md-4" v-for="comic in comics" :key="comic.id">
      <ComicMaster 
        :Title="comic.comic.title"
        :Link="comic.comic.id"
        :Image="comic.comic.image"
      />
      <button class="btn btn-danger">
        remove comic
      </button>
    </div>
  </div>
</template>

<style>

</style>