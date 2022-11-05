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
  <div class="container mt-5 pt-5">
    <form @submit.prevent="submit">
      <div class="row">
        <div class="col-md-6">
          <div class="form-group">
            <input 
              type="hidden"
              v-model="id"
            >
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
      name: this.Value,
      id: this.Id,
      method: this.apiType,
      nameError: ''
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
        switch (this.method) {
          case 'post':
            try {
              const result = await postRequest(this.name, 'Writers');
              if(result.status == 201)
              {
                this.$emit('submit', result.status);
              }
            } catch (error) {
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
                this.$emit('submit', result.status);
              }
            } catch (error) {
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

<style>

</style>