<script setup>
  import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <div class="logo-wrap">
      <RouterLink to="/"><img alt="logo" class="logo" src="/images/logo.png"/></RouterLink>
    </div>

    <nav>
      <div class="links">
        <RouterLink :to="{name: 'home'}">
          <span>Home</span>
        </RouterLink>
        <RouterLink :to="{name: 'comcis'}">
          <span>Comics</span>
        </RouterLink>
      </div>
      <div class="account-links" v-if="checkAccount">
        <RouterLink :to="{name: 'account'}">
          <span>Account</span>
        </RouterLink>
      </div>
      <div class="account-links" v-else>
        <RouterLink :to="{name: 'login'}">
          <span>Login</span>
        </RouterLink>
        <RouterLink :to="{name: 'register'}">
          <span>Sign up</span>
        </RouterLink>
      </div>
    </nav>

    <div class="account">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
        <path d="M272 304h-96C78.8 304 0 382.8 0 480c0 17.67 14.33 32 32 32h384c17.67 0 32-14.33 32-32C448 382.8 369.2 304 272 304zM48.99 464C56.89 400.9 110.8 352 176 352h96c65.16 0 119.1 48.95 127 112H48.99zM224 256c70.69 0 128-57.31 128-128c0-70.69-57.31-128-128-128S96 57.31 96 128C96 198.7 153.3 256 224 256zM224 48c44.11 0 80 35.89 80 80c0 44.11-35.89 80-80 80S144 172.1 144 128C144 83.89 179.9 48 224 48z"/>
      </svg>
    </div>
  </header>
  
  <main>
    <RouterView />
  </main>

  <footer>
    <div class="inner">
      <RouterLink to="/">Home</RouterLink>
      <RouterLink to="/"><img alt="logo" class="logo" src="/images/logo.png"/></RouterLink>
      <RouterLink to="/about">About</RouterLink>
    </div>
  </footer>
</template>

<script>
export default {
  data() {
    return {
      checkAccount: ''
    }
  },
  watch: {
    $route() {
      if(sessionStorage.getItem('user'))
      {
        this.checkAccount = 'yes'
      }
      else
      {
        this.checkAccount = ''
      }
    }
  }
}
</script>