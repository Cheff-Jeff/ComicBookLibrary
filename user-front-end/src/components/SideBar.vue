<script setup>
import { RouterLink } from "vue-router";
</script>

<template>
  <div class="wrap">
    <div class="nav-link">
      <RouterLink>
        Account details
      </RouterLink>
    </div>
    <div class="nav-link">
      <RouterLink>
        My library
      </RouterLink>
    </div>
    <div class="nav-link">
      <RouterLink>
        Logout
      </RouterLink>
    </div>
  </div>
</template>