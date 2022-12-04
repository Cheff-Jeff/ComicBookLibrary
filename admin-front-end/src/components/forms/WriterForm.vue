<script setup>
  import { postRequest, putRequest } from '@/assets/javascript/apiHelper'
  import { validateName, errNameEmp, errName } from '@/assets/javascript/validation'

  defineProps({
    Value: {
      type: String,
      default: '',
      required: false,
    },
    Id: {
      type: Number,
      default: 0,
      required: false,
    },
    apiType: {
      type: String,
      default: 'post',
      required: true
    }
  })
</script>

<template>
  <div class="page-wrap">
    <section class="form">
      <div class="title-wrap">
        <h1 v-if="method == 'post'">Add writer</h1>
        <h1 v-else>Update writer</h1>
      </div>
      <form @submit.prevent="submit">
        <div class="row">
          <div class="col-md-12">
            <input 
              type="hidden"
              v-model="id"
            >
            <div class="input-wrap">
              <input 
                type="text" 
                v-model="name"
                placeholder="Writer name"
                @blur="validate"
                @keyup="validate"
              >
            </div>
            <div v-if="nameError" class="error">
              <span>{{nameError}}</span>
            </div>
          </div>
          <div class="col-md-12" v-auto-animate>
            <div v-if="loading">
              <button type="submit" class="btn btn-custom" disabled v-if="loading">
                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid">
                  <circle cx="50" cy="50" r="32" stroke-width="8" stroke="#fff" stroke-dasharray="50.26548245743669 50.26548245743669" fill="none" stroke-linecap="round">
                    <animateTransform attributeName="transform" type="rotate" dur="1s" repeatCount="indefinite" keyTimes="0;1" values="0 50 50;360 50 50"></animateTransform>
                  </circle>
                  <circle cx="50" cy="50" r="23" stroke-width="8" stroke="#fff" stroke-dasharray="36.12831551628262 36.12831551628262" stroke-dashoffset="36.12831551628262" fill="none" stroke-linecap="round">
                    <animateTransform attributeName="transform" type="rotate" dur="1s" repeatCount="indefinite" keyTimes="0;1" values="0 50 50;-360 50 50"></animateTransform>
                  </circle>
                </svg>
              </button>
            </div>
            <div v-else>
              <div v-if="method == 'post'">
                <button class="btn btn-custom" type="submit">
                  Add writer
                </button>
              </div>
              <div v-else>
                <button class="btn btn-custom" type="submit">
                  Update writer
                </button>
              </div>
            </div>
          </div>
        </div>
      </form>
    </section>
  </div>
</template>

<script>
export default {
  data(){
    return{
      name: this.Value,
      id: this.Id,
      method: this.apiType,
      nameError: '',
      loading: ''
    }
  },
  methods: {
    validate() {
      this.nameError = this.name.length <= 0 ? errNameEmp() : 
      (validateName(this.name) ? '' : errName(this.name)) 
    },
    async submit() {
      this.validate();
      if(this.nameError == ''){
        this.loading = 'loading'
        switch (this.method) {
          case 'post':
            try {
              const result = await postRequest(this.name, 'Writers');
              if(result.status == 201)
              {
                this.loading = '';
                this.$emit('done', result.status);
              }
            } catch (error) {
              this.loading = '';
              console.log(error)
            }
            break;
          case 'put':
            try {
              const data = {
                id: this.id,
                name: this.name
              }
              const result = await putRequest(data, 'Writers')
              if(result.status == 204)
              {
                this.loading = '';
                this.$emit('done', result.status);
              }
            } catch (error) {
              this.loading = '';
              console.log(error)
            }
          default:
            break;
        }
      }
    }
  },
}
</script>

<style lang="scss" scoped>
@import "../../assets/styles/forms/writerForm.scss";
</style>