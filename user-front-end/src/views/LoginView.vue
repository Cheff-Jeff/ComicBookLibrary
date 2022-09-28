<script setup>
  import LoginForm from '../components/LoginForm.vue';
  import { RouterLink } from 'vue-router';
</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="page-wrap">
          <div class="background-wrapper">
            <img src="/images/superhero.png" alt="user-icon">
            <LoginForm/>
            <div class="register-link">
              <RouterLink :to="{name: 'register'}" class="link">
                <span>Don't have an account yet? Sign up here.</span>
              </RouterLink>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  @import "@/assets/styles/pages/Login.scss";
</style>