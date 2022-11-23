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
    <div class="comics-wrapper">
      <div class="card-row" v-for="i in Math.ceil(comics.length / 5)" :key="i">
        <div class="comic-card" v-for="comic in comics.slice((i - 1) * 5, i * 5)" :key="comic.id">
          <div class="card-head">
            <p>{{comic.title}}</p>
          </div>
          <div class="card-body">
            <div class="img-wrapper">
              <img :src="`${imgLink}/${comic.image}`" alt="comic cover"/>
            </div>
            <div class="row">
              <div class="col-md-6">
                <RouterLink :to="{name: 'updateComic', params: { id: comic.id }}" class="btn btn-custom">
                  Edit
                </RouterLink>
              </div>
              <div class="col-md-6">
                <button 
                  class="btn btn-custom-red" 
                  data-toggle="modal" 
                  data-target="#deleteModal"
                  @click="openModel(comic.id, comic.title)"
                >
                  Delete
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="wrapper" v-auto-animate>
    <div class="delete-modal" :class="modalToggle" @click="closeModal">
      <div @click.stop class="modal-wrap">
        <div class="custom-modal-head">
          <h5>Delete comic</h5>
          <svg @click="closeModal" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M175 175C184.4 165.7 199.6 165.7 208.1 175L255.1 222.1L303 175C312.4 165.7 327.6 165.7 336.1 175C346.3 184.4 346.3 199.6 336.1 208.1L289.9 255.1L336.1 303C346.3 312.4 346.3 327.6 336.1 336.1C327.6 346.3 312.4 346.3 303 336.1L255.1 289.9L208.1 336.1C199.6 346.3 184.4 346.3 175 336.1C165.7 327.6 165.7 312.4 175 303L222.1 255.1L175 208.1C165.7 199.6 165.7 184.4 175 175V175zM512 256C512 397.4 397.4 512 256 512C114.6 512 0 397.4 0 256C0 114.6 114.6 0 256 0C397.4 0 512 114.6 512 256zM256 48C141.1 48 48 141.1 48 256C48 370.9 141.1 464 256 464C370.9 464 464 370.9 464 256C464 141.1 370.9 48 256 48z"/></svg>
        </div>
        <div class="custom-modal-body">
          <p>
            Are you sure you want to delete comic: {{txt}}
          </p>
        </div>
        <div class="custom-modal-footer">
          <div class="row">
            <div class="col-md-6">
              <button type="button" class="btn btn-custom" @click="closeModal">Cancel</button>
            </div>
            <div class="col-md-6">
              <button type="button" class="btn btn-custom-red" @click="deleteComicAsync">Delete</button>
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
      modalToggle: 'hide'
    }
  },
  methods: {
    openModel(Id, Txt) {
      this.id = Id,
      this.txt = Txt
      this.modalToggle = 'open'
    },
    closeModal() {
      this.id = '',
      this.txt = '',
      this.modalToggle = 'hide'
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

<style lang="scss" scoped>
@import "../assets/styles/pages/ComicsOverview.scss";
</style>