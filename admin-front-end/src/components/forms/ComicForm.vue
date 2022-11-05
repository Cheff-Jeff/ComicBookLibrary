<script setup>
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import { uploadImage } from '@/assets/javascript/comicApiHelper'
  import { 
    validateTitle, validateDescription, validateId, validateFile, errTitleEmp, 
    errTitle, errDescriptionEmp, errDescription, errWriterIdEmp,errWriterId, 
    errArtistIdEmp, errArtistId, errCoverArtistIdEmp,errCoverArtistId, 
    errPublicherIdEmp, errPublicherId, errImageEmp, errImage
  } from '@/assets/javascript/validation'

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
      image: '',
      imageError: '',
      newComic: {
        Id: 0,
        Title: this.Title,
        Description: this.Description,
        Image: "string",
        PublisherId: this.publicher,
        Publisher: {
          Id: 0,
          Name: "string"
        },
        CoverArtistId: this.CoverArtist,
        CoverArtist: {
          Id: 0,
          Name: "string"
        },
        WriterId: this.Writer,
        Writer: {
          Id: 0,
          Name: "string"
        },
        ArtistId: this.Artist,
        Artist: {
          Id: 0,
          Name: "string"
        },
        ImageFile: ''
      }
    }
  },
  methods: {
    checkImage(e) {
      this.image = e.target.files[0]
      const type = e.target.files[0].type.split('/')
      this.imageError = this.image == '' ? errImageEmp() : (
        validateFile(type[1]) ? '' : errImage()
      )
      console.log(this.imageError)
    },
    setFile(file){
      this.newComic.ImageFile = file
    },
    checkTitle(){
      this.TitleError = this.Title == '' ? errTitleEmp() : (
        validateTitle(this.Title) ? '' : errTitle(this.Title)
      )
    },
    checkDescription(){
      this.DescriptionError = this.Description == '' ? errDescriptionEmp() : (
        validateDescription(this.Description) ? '' : errDescription(this.Description)
      )
    },
    checkWhriter(){
      this.WriterError = this.Writer == '' ? errWriterIdEmp() : (
        validateId(this.Writer) ? '' : errWriterId()
      )
    },
    checkPublicher(){
      this.PucherError = this.Publicher == ''? errPublicherIdEmp() : (
        validateId(this.Publicher) ? '' : errPublicherId()
      )
    },
    checkArtist(){
      this.ArtisError = this.Artist == '' ? errArtistIdEmp() : (
        validateId(this.Artist) ? '' : errArtistId()
      )
    },
    checkCoverArtist(){
      this.CoverArtisError = this.CoverArtist == '' ? errCoverArtistIdEmp() : (
        validateId(this.CoverArtist) ? '' : errCoverArtistId()
      )
    },
    submit() {
      this.checkImage(); this.checkTitle(); this.checkDescription()
      this.checkWhriter(); this.checkArtist(); this.checkCoverArtist()
      this.checkPublicher()
      if(this.TitleError == '', this.DescriptionError == '', this.WriterError == '',
      this.ArtisError == '', this.CoverArtisError == '', this.PucherError == '', 
      this.imageError == ''){
        this.setFile(this.image)
      }
    }
  }
}
</script>

<style>

</style>