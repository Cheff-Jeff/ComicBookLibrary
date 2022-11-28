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
  const imgLink = import.meta.env.VITE_IMAGES

  defineProps({
    apiType: { type: String, default: 'post', required: true },
    oldId: { type: Number, default: 0, required: false, },
    oldTitle: { type: String, default: '', required: false, },
    oldDescription: { type: String, default: '', required: false, },
    oldImg: { type: String, default: '', required: false, },
    oldPublicherId: { type: Number, default: 0, required: false, },
    oldPublicher: { type: String, default: '', required: false, },
    oldWriterId: { type: Number, default: 0, required: false, },
    oldWriter: { type: String, default: '', required: false, },
    oldArtistId: { type: Number, default: 0, required: false, },
    oldArtist: { type: String, default: '', required: false, },
    oldCoverArtistId: { type: Number, default: 0, required: false, },
    oldCoverArtist: { type: String, default: '', required: false, },
  })
</script>

<template>
  <div class="page-wrap">
    <section class="form">
      <div class="title-wrap">
        <h1 v-if="apiType == 'post'">Add comic</h1>
        <h1 v-else>Update comic</h1>
      </div>
      <form @submit.prevent="submit">
        <div class="row">
          <div class="col-md-6 mb-2">
            <div class="input-wrap">
              <input 
                v-model="Title" 
                @blur="checkTitle" 
                @keyup="checkTitle" 
                class="form-control" 
                type="text" 
                name="Title" 
                id=""
                placeholder="Comic title"
              >
            </div>
            <div v-if="TitleError" class="error">
              <span>{{TitleError}}</span>
            </div>
          </div>
          <div class="col-md-6 mb-2">
            <div v-if="oldImg">
              <img :src="`${imgLink}/${oldImg}`" alt="oldCover" style="max-width: 150px;">
            </div>
            <div class="input-wrap">
              <input class="form-control" type="file" id="formFile" @change="checkImage">
            </div>
            <div v-if="imageError" class="error">
              <span>{{imageError}}</span>
            </div>
          </div>
          <div class="col-md-12 mb-2">
            <div class="input-wrap">
              <textarea placeholder="Comic description" v-model="Description" @blur="checkDescription" @keyup="checkDescription" class="form-control" name="Description" rows="3"></textarea>
            </div>
            <div v-if="DescriptionError" class="error">
              <span>{{DescriptionError}}</span>
            </div>
          </div>
          <div class="col-md-6">
            <span v-if="oldPublicherId && oldPublicher">
              currend publicher: {{oldPublicher}}
            </span>
            <div class="input-wrap">
              <select name="" class="form-control" v-model="Publicher" @change="checkPublicher">
                <option v-if="oldPublicherId" value="" disabled selected>Select a new publicher.</option>
                <option v-else value="" disabled selected>Select a publicher.</option>
                <option 
                  v-for="publicher in publichers"
                  :key="publicher.id"
                  :value="publicher.id">
                  <span>
                    {{publicher.name}}
                  </span>
                </option>
              </select>
              <div v-if="PucherError" class="error">
                <span>{{PucherError}}</span>>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <span v-if="oldWriterId && oldWriter">
              currend writer: {{oldWriter}}
            </span>
            <div class="input-wrap">
              <select name="" class="form-control" v-model="Writer" @change="checkWhriter">
                <option v-if="oldWriterId" value="" disabled selected>Select a new writer.</option>
                <option v-else value="" disabled selected>Select a writer.</option>
                <option 
                  v-for="writer in writers"
                  :key="writer.id"
                  :value="writer.id">
                  <span>
                    {{writer.name}}
                  </span>
                </option>
              </select>
              <div v-if="WriterError" class="error">
                <span>{{WriterError}}</span>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <span v-if="oldArtistId && oldArtist">
              currend artist: {{oldArtist}}
            </span>
            <div class="input-wrap">
              <select name="" class="form-control" v-model="Artist" @change="checkArtist">
                <option v-if="oldArtistId" value="" disabled selected>Select a new artist.</option>
                <option v-else value="" disabled selected>Select an artist.</option>
                <option 
                  v-for="artist in artists"
                  :key="artist.id"
                  :value="artist.id">
                  <span>
                    {{artist.name}}
                  </span>
                </option>
              </select>
              <div v-if="ArtisError" class="error">
                <span>{{ArtisError}}</span>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <span v-if="oldCoverArtistId && oldCoverArtist">
              currend cover artist: {{oldCoverArtist}}
            </span>
            <div class="input-wrap">
              <select name="" class="form-control" v-model="CoverArtist" @change="checkCoverArtist">
                <option v-if="oldCoverArtistId" value="" disabled selected>Select a new cover artist.</option>
                <option v-else value="" disabled selected>Select a cover artist.</option>
                <option 
                  v-for="artist in artists"
                  :key="artist.id"
                  :value="artist.id">
                  <span>
                    {{artist.name}}
                  </span>
                </option>
              </select>
              <div v-if="CoverArtisError" class="error">
                <span>{{CoverArtisError}}</span>
              </div>
            </div>
          </div>
        </div>
        <button type="submit" class="btn btn-custom">
          Add comic
        </button>
      </form>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return{
      Title: this.oldTitle,
      TitleError: '',
      Description: this.oldDescription,
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
      },
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
      if(this.image){
        this.newComic.ImageFile = this.image
        this.newComic.Image = "string"
      }
      else if(this.oldImg){
        this.newComic.Image = this.oldImg
        this.newComic.ImageFile = ''
      }
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
        this.checkTitle(); this.checkDescription()
        if(this.image){ this.valitImage() }
        if(!this.Publicher){ this.Publicher = this.oldPublicherId }
        if(!this.Writer){ this.Writer = this.oldWriterId }
        if(!this.Artist){ this.Artist = this.oldArtistId }
        if(!this.CoverArtist){ this.CoverArtist = this.oldCoverArtistId }

        if(this.TitleError == '', this.DescriptionError == '', this.WriterError == '',
        this.ArtisError == '', this.CoverArtisError == '', this.PucherError == '', this.imageError == '')
        {
          this.setNewComic()
          try {
            console.log(this.newComic)
            const result = await putComic(this.newComic, this.newComic.Id)
            if(result.status == 201)
            {
              console.log('done')
              this.$emit('done', result.status);
            }
          } catch (error) {
            console.log(error)
          }
        }
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
              this.$emit('done', result.status);
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

<style lang="scss" scoped>
@import "../../assets/styles/forms/comicForm.scss";
</style>