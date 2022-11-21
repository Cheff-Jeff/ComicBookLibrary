<script setup>
  const imgLink = import.meta.env.VITE_IMAGES

  defineProps({
    Title: {
      type: String,
      required: true,
      default: "Lorem",
    },
    Descriptin: {
      type: String,
      required: true,
      default: `Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
      sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
      Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris 
      nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in 
      reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla 
      pariatur. Excepteur sint occaecat cupidatat non proident, 
      sunt in culpa qui officia deserunt mollit anim id est laborum.`,
    },
    Image: {
      type: String,
      default: "defaultComic.jpg",
      required: true,
    },
    Publisher: {
      type: String,
      required: true,
      default: "Marvel",
    },
    Writer: {
      type: String,
      required: true,
      default: "Stan Lee",
    },
    Artist: {
      type: String,
      required: true,
      default: "Steve Mcniven",
    },
    CoverArtist: {
      type: String,
      required: true,
      default: "Steve Mcniven",
    },
  })
</script>

<template>
  <section class="content">
    <div class="background" :style="{ 'background-image': `url(${imgLink}/${this.Image})` }"></div>
    <div class="comic-wrap">
      <div class="container">
        <div class="row">
          <div class="col-md-5">
            <div class="img-wrap">
              <img :src="`${imgLink}/${this.Image}`" alt="comic cover">
            </div>
          </div>
          <div class="col-md-7">
            <div class="info">
              <div class="wrap">
                <h2>{{Title}}</h2>
                <div class="info-block">
                  <p>Writer:</p>
                  <p>{{Writer}}</p>
                </div>
                <div class="info-block">
                  <p>Publisher:</p>
                  <p>{{Publisher}}</p>
                </div>
                <div class="info-block">
                  <p>Artist:</p>
                  <p>{{Artist}}</p>
                </div>
                <div class="info-block">
                  <p>Cover artist:</p>
                  <p>{{CoverArtist}}</p>
                </div>
              </div>
              <div class="btn-wrap">
                <button class="btn btn-custom" @click="$emit('AddComic')">
                  Add to library
                </button>
              </div>
            </div>
          </div>
          <div class="col-md-12">
            <div class="desc">
              <span v-html="Descriptin">
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
  @import "@/assets/styles/components/ComicDetail.scss";
</style>