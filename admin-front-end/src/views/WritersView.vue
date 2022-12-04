<script setup>
  import Header from '@/components/Header.vue';
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import { RouterLink } from 'vue-router';
  import { deleteRequest } from '@/assets/javascript/apiHelper'

  const writers = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}`);
</script>

<template>
  <Header></Header>
  <div class="page-wrapper">
    <div class="container">
      <div class="row">
        <div class="col-md-3 spacer" v-for="writer in writers" :key="writer.id">
          <div class="item-wrap">
            <p>
              {{writer.name}}
            </p>
            <div class="row justify-content-between">
              <div class="col-md-6">
                <RouterLink :to="{name: 'updateWriter', params: { id: writer.id }}" class="btn btn-custom">
                  Edit
                </RouterLink>
              </div>
              <div class="col-md-6">
                <button 
                  class="btn btn-custom-red" 
                  data-toggle="modal" 
                  data-target="#deleteModal"
                  @click="openModel(writer.id, writer.name)"
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
          <h5>Delete writer</h5>
          <svg @click="closeModal" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M175 175C184.4 165.7 199.6 165.7 208.1 175L255.1 222.1L303 175C312.4 165.7 327.6 165.7 336.1 175C346.3 184.4 346.3 199.6 336.1 208.1L289.9 255.1L336.1 303C346.3 312.4 346.3 327.6 336.1 336.1C327.6 346.3 312.4 346.3 303 336.1L255.1 289.9L208.1 336.1C199.6 346.3 184.4 346.3 175 336.1C165.7 327.6 165.7 312.4 175 303L222.1 255.1L175 208.1C165.7 199.6 165.7 184.4 175 175V175zM512 256C512 397.4 397.4 512 256 512C114.6 512 0 397.4 0 256C0 114.6 114.6 0 256 0C397.4 0 512 114.6 512 256zM256 48C141.1 48 48 141.1 48 256C48 370.9 141.1 464 256 464C370.9 464 464 370.9 464 256C464 141.1 370.9 48 256 48z"/></svg>
        </div>
        <div class="custom-modal-body">
          <p>
              Are you sure you want to delete writer: {{txt}}
          </p>
        </div>
        <div class="custom-modal-footer">
          <div class="row">
            <div class="col-md-6">
              <button type="button" class="btn btn-custom" @click="closeModal">Cancel</button>
            </div>
            <div class="col-md-6">
              <button type="button" class="btn btn-custom-red" @click="deleteWriter">Delete</button>
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
      console.log(Id, Txt)
      this.id = Id,
      this.txt = Txt
      this.modalToggle = 'open'
    },
    closeModal() {
      this.id = '',
      this.txt = '',
      this.modalToggle = 'hide'
    },
    async deleteWriter(){
      await deleteRequest(this.id, 'Writers')
      this.$router.go()
    }
  },
}
</script>

<style lang="scss" scoped>
  @import "../assets/styles/pages/Writers.scss";
</style>