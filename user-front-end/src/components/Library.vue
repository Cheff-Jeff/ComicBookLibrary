<script setup>
  import {getUserLibrary} from '@/assets/javascript/library'
  import ComicMaster from '@/components/ComicMaster.vue';
  import {removeItem} from '@/assets/javascript/library'
  import { RouterLink } from 'vue-router';
  const LibraryItems = getUserLibrary(sessionStorage.getItem('user'));
</script>

<template>
  <div class="lib-wrap">
    <div class="row spacer" v-if="LibraryItems && LibraryItems.length > 0">
      <div class="col-md-3" v-for="item in LibraryItems" :key="item.id">
        <div class="comic-wrap">
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
    </div>
    <div class="no-content" v-else>
      <div class="row">
        <div class="col-md-12">
          <p>You haven't got any comics in your collection yet.</p>
          <RouterLink :to="{name: 'comcis'}" class="btn btn-custom">
            Browse comics
          </RouterLink>
        </div>
      </div>
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

<style scoped lang="scss">
  @import '../assets/styles/components/Library.scss';
</style>