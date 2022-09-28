<script setup>
import BannerRight from '../components/BannerRight.vue';
import ComicMaster from '../components/ComicMaster.vue';
</script>

<template>
  <BannerRight 
    Title="Browse comics."
  />
  <section class="comics">
    <div class="container lesser">
      <div class="row">
        <div class="col-md-3">
          <!-- filter gaat hier-->
        </div>
        <div class="col-md-9">
          <div class="row">
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
            <div class="col-md-3 smaller">
              <ComicMaster Title="Test" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/pages/Comics.scss";
</style>