<script setup>
import { RouterLink } from 'vue-router'
import Header from '../components/Header.vue';
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
  </div>
</template>

<style>

</style>