<script setup>
  import { postRequest } from '../assets/javascript/postData'
  import { validateName } from '../assets/javascript/validation'
</script>

<template>
  <div class="container mt-5 pt-5">
    <form @submit.prevent="submit">
      <div class="row">
        <div class="col-md-6">
          <div class="form-group">
            <input 
              type="text" 
              class="form-control"
              v-model="name"
              @blur="validate"
              @keyup="validate"
            >
          </div>
        </div>
        <div class="col-md-6">
          <button class="btn btn-primary" type="submit">
            <span>Add writer</span>
          </button>
        </div>
        <div class="col-md-12">
          <span>{{nameError}}</span>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  data(){
    return{
      name: '',
      nameError: ''
    }
  },
  methods: {
    validate() {
      this.nameError = this.name.length <= 0 ? 'Name can not be empty.' : 
      (validateName(this.name) ? '' : `${this.name} is not a name.`) 
    },
    async submit() {
      this.validate();
      if(this.nameError == ''){
        try {
          const result = await postRequest(this.name, 'Writers');
          if(result.status == 201)
          {
            this.$emit('submit', result.status);
          }
        } catch (error) {
          console.log(error)
        }
      }
    }
  },
}
</script>

<style>

</style>