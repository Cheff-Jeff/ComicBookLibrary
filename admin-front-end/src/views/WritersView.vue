<script setup>
  import Header from '../components/Header.vue';
  import { useFetch } from '../assets/javascript/fetchNewComics';
  import { RouterLink } from 'vue-router';
  import { deleteRequest } from '@/assets/javascript/apiHelper'

  const writers = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}`);
</script>

<template>
  <Header></Header>
  <div class="constainer pt-5">
    <div class="row pt-5">
      <div class="col-md-12 pt-5">
        <div class="row">
          <div class="col-md-3" v-for="writer in writers" :key="writer.id">
            <p>
              {{writer.name}}
            </p>
            <div class="row">
              <div class="col-md-6">
                <RouterLink :to="{name: 'updateWriter', params: { id: writer.id }}">
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
                  @click="openModel(writer.id, writer.name)"
                >
                  <span>Delete</span>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="wrapper" v-auto-animate>
    <div class="modal" :class="modalToggle" @click="closeModal">
      <div class="container mt-5 bg-white">
        <div class="modal-header">
          <h5>Delete writer</h5>
          <button type="button" class="close" @click="closeModal">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <p>
            Are you sure you want to delete writer:
          </p>
          <p>{{txt}}</p>
        </div>
        <div class="modal-footer">
          <div class="row">
            <div class="col-md-6">
              <button type="button" class="btn btn-secondary" @click="closeModal">Cancel</button>
            </div>
            <div class="col-md-6">
              <button type="button" class="btn btn-danger" @click="deleteWriter">Delete</button>
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
      console.log(Id, Txt)
      this.id = Id,
      this.txt = Txt
      this.modalToggle = 'd-block'
    },
    closeModal() {
      this.id = '',
      this.txt = '',
      this.modalToggle = 'd-none'
    },
    async deleteWriter(){
      await deleteRequest(this.id, 'Writers')
      this.$router.go()
    }
  },
}
</script>