<script setup>
  import { RouterLink } from 'vue-router'
  import Header from '@/components/Header.vue';
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import { deleteComic } from '@/assets/javascript/comicApiHelper'

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
      <div class="col-md-3" v-for="comic in comics" :key="comic.id">
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
              @click="openModel(comic.id, comic.title)"
            >
              <span>Delete</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="wrapper" v-auto-animate>
    <div class="modal" :class="modalToggle" @click="closeModal">
      <div class="container mt-5 bg-white">
        <div class="modal-header">
          <h5>Delete Comic</h5>
          <button type="button" class="close" @click="closeModal">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <p class="text-dark">
            Are you sure you want to delete this comic:
          </p>
          <p class="text-dark">{{txt}}</p>
        </div>
        <div class="modal-footer">
          <div class="row">
            <div class="col-md-6">
              <button type="button" class="btn btn-secondary" @click="closeModal">Cancel</button>
            </div>
            <div class="col-md-6">
              <button type="button" class="btn btn-danger" @click="deleteComicAsync">Delete</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
  data() {
    return {
      id: '',
      txt: '',
      modalToggle: 'd-none'
    }
  },
  methods: {
    openModel(Id, Txt) {
      this.id = Id,
      this.txt = Txt
      this.modalToggle = 'd-block'
    },
    closeModal() {
      this.id = '',
      this.txt = '',
      this.modalToggle = 'd-none'
    },
    async deleteComicAsync(){
      await deleteComic(this.id)
      this.$router.go()
    }
  },
}
</script>

<style>

</style>