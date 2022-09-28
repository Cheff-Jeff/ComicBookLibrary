<script setup>
  import RegisterForm from '../components/RegisterForm.vue';
  import { RouterLink } from 'vue-router';
</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="page-wrap">
          <div class="background-wrapper">
            <img src="/images/superhero.png" alt="user-icon">
            <RegisterForm />
            <div class="register-link">
              <RouterLink :to="{name: 'login'}" class="link">
                <span>Already have an account? Sign in here.</span>
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