<script setup>
  import {getUserLibrary} from '@/assets/javascript/library'
  import ComicMaster from '@/components/ComicMaster.vue';
  import {removeItem} from '@/assets/javascript/library'
  import { RouterLink } from 'vue-router';
  import { ComicHub } from '@/assets/javascript/SignalR';

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
          <button class="btn btn-danger" @click="remove(item.id, item.comic.id)">
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
  data() {
    return {
      hub: null
    }
  },
  mounted() {
    this.hub = new ComicHub()
  },
  methods: {
    async remove(id, comicId){
      let result = await removeItem(id)
      console.log(result);
      this.hub.removePopularity(comicId)
      this.$router.go()
    }
  },
}
</script>

<style scoped lang="scss">
  @import '../assets/styles/components/Library.scss';
</style>