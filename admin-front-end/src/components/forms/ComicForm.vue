<script setup>
  import { useFetch } from '../../assets/javascript/fetchNewComics';
  import { uploadImage } from '../../assets/javascript/comicApiHelper'

  const publichers = useFetch(`${import.meta.env.VITE_API_PUBLICHERS_URL}`);
  const writers = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}`);
  const artists = useFetch(`${import.meta.env.VITE_API_ARTISTS_URL}`);
</script>

<template>
  <form @submit.prevent="submit">
    <div class="row mt-5 pt-5">
      <div class="col-md-6">
        <div class="input-wrapper form-group">
          <input class="form-control" type="text" name="Title" id="">
        </div>
      </div>
      <div class="col-md-6">
        <div class="input-wrapper form-group">
          <input class="form-control" type="file" id="formFile" @change="checkImage">
        </div>
      </div>
      <div class="col-md-12">
        <div class="input-wrapper form-group">
          <textarea class="form-control" name="Description" rows="3"></textarea>
        </div>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Publicher">
          <option value="" disabled selected>Select a publicher</option>
          <option 
            v-for="publicher in publichers"
            :key="publicher.id"
            :value="publicher.id">
            <span>
              {{publicher.name}}
            </span>
          </option>
        </select>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Writer">
          <option value="" disabled selected>Select a Writer</option>
          <option 
            v-for="writer in writers"
            :key="writer.id"
            :value="writer.id">
            <span>
              {{writer.name}}
            </span>
          </option>
        </select>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Artist">
          <option value="" disabled selected>Select a Artist</option>
          <option 
            v-for="artist in artists"
            :key="artist.id"
            :value="artist.id">
            <span>
              {{artist.name}}
            </span>
          </option>
        </select>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="CoverArtist">
          <option value="" disabled selected>Select a cover artist</option>
          <option 
            v-for="artist in artists"
            :key="artist.id"
            :value="artist.id">
            <span>
              {{artist.name}}
            </span>
          </option>
        </select>
      </div>
    </div>
    <button type="submit" class="btn btn-primary">
      Add comic
    </button>
  </form>
  <p>{{Publicher}}</p>
  <p>{{Writer}}</p>
  <p>{{Artist}}</p>
  <!-- <p>{{publichers[0].id}}</p> -->
</template>

<script>
export default {
  data() {
    return{
      Title: '',
      TitleError: '',
      Description: '',
      DescriptionError: '',
      Writer: '',
      WriterError: '',
      Publicher: '',
      PucherError: '',
      Artist: '',
      ArtisError: '',
      CoverArtist: '',
      CoverArtisError: '',
      image: ''
    }
  },
  methods: {
    checkImage(e) {
      uploadImage(e.target.files[0]);
    },
    submit() {

    }
  }
}
</script>

<style>

</style>