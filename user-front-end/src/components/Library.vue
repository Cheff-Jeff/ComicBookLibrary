<script setup>
  import {getUserLibrary} from '@/assets/javascript/library'
  import {removeItem} from '@/assets/javascript/library'
  import { RouterLink } from 'vue-router';
  const imgLink = import.meta.env.VITE_IMAGES
  const LibraryItems = getUserLibrary(sessionStorage.getItem('user'));
</script>

<template>
  <div class="lib-wrap">
    <div class="comics-wrapper" v-if="LibraryItems && LibraryItems.length > 0">
      <div class="card-row" v-for="i in Math.ceil(LibraryItems.length / 5)" :key="i">
        <div class="comic-card" v-for="item in LibraryItems.slice((i - 1) * 5, i * 5)" :key="item.id">
          <RouterLink :to="{ name: 'comicDetail', params: { slug: item.comic.id } }">
            <div class="card-head">
              <p>{{item.comic.title}}</p>
            </div>
            <div class="card-body">
              <div class="img-wrapper">
                <img :src="`${imgLink}/${item.comic.image}`" alt="comic cover"/>
              </div>
              <div class="row justify-content-center">
                <div class="col-md-12 custom-spacer">
                  <button class="btn btn-custom-red" @click.prevent="remove(item.id)">
                    remove comic
                  </button>
                </div>
              </div>
            </div>
          </RouterLink>
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