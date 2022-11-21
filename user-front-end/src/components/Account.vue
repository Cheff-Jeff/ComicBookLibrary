<script setup>
  import { useFetch } from '../assets/javascript/fetchNewComics';
  const user = useFetch(`${import.meta.env.VITE_API_USERS}/${sessionStorage.getItem('user')}`);
</script>

<template>
  <div class="account-info">
    <div class="container" v-if="user">
      <div class="row">
        <div class="col-md-2">
          <p>First name:</p>
        </div>
        <div class="col-md-6">
          <p>{{user.firstName}}</p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-2">
          <p>Last name:</p>
        </div>
        <div class="col-md-6">
          <p>{{user.lastName}}</p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-2">
          <p>Email:</p>
        </div>
        <div class="col-md-6">
          <p>{{user.email}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
  @import "../assets/styles/components/Account.scss";
</style>