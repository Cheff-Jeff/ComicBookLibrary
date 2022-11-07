<script setup>
  import { useFetch } from '@/assets/javascript/fetchNewComics';
  import { postComic, putComic } from '@/assets/javascript/comicApiHelper'
  import { 
    validateTitle, validateDescription, validateId, validateFile, errTitleEmp, 
    errTitle, errDescriptionEmp, errDescription, errWriterIdEmp,errWriterId, 
    errArtistIdEmp, errArtistId, errCoverArtistIdEmp,errCoverArtistId, 
    errPublicherIdEmp, errPublicherId, errImageEmp, errImage
  } from '@/assets/javascript/validation'

  const publichers = useFetch(`${import.meta.env.VITE_API_PUBLICHERS_URL}`);
  const writers = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}`);
  const artists = useFetch(`${import.meta.env.VITE_API_ARTISTS_URL}`);

  defineProps({
    apiType: { type: String, default: 'post', required: true },
    oldId: { type: Number, default: 0, required: false, },
    oldTitle: { type: String, default: '', required: false, },
    oldDescription: { type: String, default: '', required: false, },
    oldImg: { type: String, default: '', required: false, },
    oldPublicherId: { type: Number, default: 0, required: false, },
    oldWriterId: { type: Number, default: 0, required: false, },
    oldArtistId: { type: Number, default: 0, required: false, },
    oldCoverArtistId: { type: Number, default: 0, required: false, },
  })
</script>

<template>
  <form @submit.prevent="submit">
    <div class="row mt-5 pt-5">
      <div class="col-md-6">
        <div class="input-wrapper form-group">
          <input v-model="Title" @blur="checkTitle" @keyup="checkTitle" class="form-control" type="text" name="Title" id="">
          <span>{{TitleError}}</span>
        </div>
      </div>
      <div class="col-md-6">
        <div class="input-wrapper form-group">
          <input class="form-control" type="file" id="formFile" @change="checkImage">
          <span>{{imageError}}</span>
        </div>
      </div>
      <div class="col-md-12">
        <div class="input-wrapper form-group">
          <textarea v-model="Description" @blur="checkDescription" @keyup="checkDescription" class="form-control" name="Description" rows="3"></textarea>
          <span>{{DescriptionError}}</span>
        </div>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Publicher" @change="checkPublicher">
          <option :v-if="!oldPublicherId" value="" disabled selected>Select a publicher</option>
          <option 
            v-for="publicher in publichers"
            :key="publicher.id"
            :value="publicher.id">
            <span>
              {{publicher.name}}
            </span>
          </option>
        </select>
        <span>{{PucherError}}</span>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Writer" @change="checkWhriter">
          <option :v-if="!oldWriterId" value="" disabled selected>Select a Writer</option>
          <option 
            v-for="writer in writers"
            :key="writer.id"
            :value="writer.id">
            <span>
              {{writer.name}}
            </span>
          </option>
        </select>
        <span>{{WriterError}}</span>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="Artist" @change="checkArtist">
          <option v-if="!oldArtistId" value="" disabled selected>Select a Artist</option>
          <option 
            v-for="artist in artists"
            :key="artist.id"
            :value="artist.id">
            <span>
              {{artist.name}}
            </span>
          </option>
        </select>
        <span>{{ArtisError}}</span>
      </div>
      <div class="col-md-3">
        <select name="" class="form-control" v-model="CoverArtist" @change="checkCoverArtist">
          <option v-if="!oldCoverArtistId" value="" disabled selected>Select a cover artist</option>
          <option 
            v-for="artist in artists"
            :key="artist.id"
            :value="artist.id">
            <span>
              {{artist.name}}
            </span>
          </option>
        </select>
        <span>{{CoverArtisError}}</span>
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
      Title: this.oldTitle,
      TitleError: '',
      Description: this.oldDescription,
      DescriptionError: '',
      Writer: this.oldWriterId,
      WriterError: '',
      Publicher: this.oldPublicherId,
      PucherError: '',
      Artist: this.oldArtistId,
      ArtisError: '',
      CoverArtist: this.oldCoverArtistId,
      CoverArtisError: '',
      image: this.oldImg,
      imageError: '',
      imgType: '',
      newComic: {
        Id: this.oldId,
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
      console.log(e)
      console.log(e.target.files)
      this.image = e.target.files[0]
      this.imgType = e.target.files[0].type.split('/')
      this.imgType = this.imgType[1]
      this.valitImage()
    },
    valitImage(){
      this.imageError = this.image == '' ? errImageEmp() : (
        validateFile(this.imgType) ? '' : errImage()
      )
    },
    setNewComic(){
      this.newComic.Title = this.Title
      this.newComic.Description = this.Description
      this.newComic.PublisherId = this.Publicher
      this.newComic.CoverArtistId = this.CoverArtist
      this.newComic.WriterId = this.Writer
      this.newComic.ArtistId = this.Artist
      this.newComic.ImageFile = this.image
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
    async submit() {
      if(this.apiType == 'put'){
        
      }
      else{
        this.valitImage(); this.checkTitle(); this.checkDescription()
        this.checkWhriter(); this.checkArtist(); this.checkCoverArtist()
        this.checkPublicher()

        if(this.TitleError == '', this.DescriptionError == '', this.WriterError == '',
        this.ArtisError == '', this.CoverArtisError == '', this.PucherError == '', this.imageError == '')
        {
          this.setNewComic()
          try {
            console.log(this.newComic)
            const result = await postComic(this.newComic)
            if(result.status == 201)
            {
              console.log('done')
              this.$emit('submit', result.status);
            }
          } catch (error) {
            console.log(error)
          }
        }
      }
    }
  }
}
</script>

<style>

</style>