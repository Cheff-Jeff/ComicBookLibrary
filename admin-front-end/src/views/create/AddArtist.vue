<script setup>
  import Header from '@/components/Header.vue';
  import ArtistsForm from '@/components/forms/ArtistsForm.vue';
</script>

<template>
  <Header />
  <div class="container">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <ArtistsForm @done='redirect' apiType='post'/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    redirect() {
      this.$router.push({name: 'Artists'});
    }
  }
}
</script>

<style>

</style>