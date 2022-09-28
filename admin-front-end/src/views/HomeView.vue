<script setup>
  import LoginForm from '../components/LoginForm.vue';
</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="page-wrap">
          <div class="background-wrapper">
            <img src="@/assets/images/superhero.png" alt="user-icon">
            <LoginForm/>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  @import "@/assets/styles/pages/Login.scss";
</style>