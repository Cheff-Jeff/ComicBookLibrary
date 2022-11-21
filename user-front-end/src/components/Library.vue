<script setup>
  import {getUserLibrary} from '@/assets/javascript/library'
  import ComicMaster from '@/components/ComicMaster.vue';
  import {removeItem} from '@/assets/javascript/library'
  const LibraryItems = getUserLibrary(sessionStorage.getItem('user'));
</script>

<template>
  <div class="row" v-if="LibraryItems">
    <div class="col-md-4" v-for="item in LibraryItems" :key="item.id">
      <ComicMaster 
        :Title="item.comic.title"
        :Link="item.comic.id"
        :Image="item.comic.image"
      />
      <button class="btn btn-danger" @click="remove(item.id)">
        remove comic
      </button>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    async remove(id){
      let result = await removeItem(id)
      console.log(result);
      this.$router.go()
    }
  },
}
</script>

<style>

</style>