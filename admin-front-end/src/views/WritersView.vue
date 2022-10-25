<script setup>
  import Header from '../components/Header.vue';
  import { useFetch } from '../assets/javascript/fetchNewComics';
  import { RouterLink } from 'vue-router';
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
                <span class="btn btn-danger">
                  Delete
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>