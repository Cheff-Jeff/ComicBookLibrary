<script setup>
  import Header from '@/components/Header.vue';
  import ComicForm from '@/components/forms/ComicForm.vue'
</script>

<template>
  <Header></Header>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <ComicForm apiType="post"></ComicForm>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>