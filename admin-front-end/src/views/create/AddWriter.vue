<script setup>
  import Header from '@/components/Header.vue';
  import WriterForm from '@/components/forms/WriterForm.vue'
</script>

<template>
  <Header />
  <div class="container">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <WriterForm @submit='redirect' apiType='post'/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    redirect() {
      this.$router.push("Writers");
    }
  }
}
</script>

<style>

</style>