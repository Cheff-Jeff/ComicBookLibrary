<script setup>
  import { checkUser } from "../assets/javascript/authentication"
</script>

<template>
  <form @submit.prevent="submitHandler">
    <div class="wrap">
      <div class="input-wrap">
        <div class="icon">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
            <path d="M370.7 96.1C346.1 39.5 289.7 0 224 0S101.9 39.5 77.3 96.1C60.9 97.5 48 111.2 48 128v64c0 16.8 12.9 30.5 29.3 31.9C101.9 280.5 158.3 320 224 320s122.1-39.5 146.7-96.1c16.4-1.4 29.3-15.1 29.3-31.9V128c0-16.8-12.9-30.5-29.3-31.9zM336 144v16c0 53-43 96-96 96H208c-53 0-96-43-96-96V144c0-26.5 21.5-48 48-48H288c26.5 0 48 21.5 48 48zM189.3 162.7l-6-21.2c-.9-3.3-3.9-5.5-7.3-5.5s-6.4 2.2-7.3 5.5l-6 21.2-21.2 6c-3.3 .9-5.5 3.9-5.5 7.3s2.2 6.4 5.5 7.3l21.2 6 6 21.2c.9 3.3 3.9 5.5 7.3 5.5s6.4-2.2 7.3-5.5l6-21.2 21.2-6c3.3-.9 5.5-3.9 5.5-7.3s-2.2-6.4-5.5-7.3l-21.2-6zM112.7 316.5C46.7 342.6 0 407 0 482.3C0 498.7 13.3 512 29.7 512H128V448c0-17.7 14.3-32 32-32H288c17.7 0 32 14.3 32 32v64l98.3 0c16.4 0 29.7-13.3 29.7-29.7c0-75.3-46.7-139.7-112.7-165.8C303.9 338.8 265.5 352 224 352s-79.9-13.2-111.3-35.5zM176 448c-8.8 0-16 7.2-16 16v48h32V464c0-8.8-7.2-16-16-16zm96 32c8.8 0 16-7.2 16-16s-7.2-16-16-16s-16 7.2-16 16s7.2 16 16 16z"/>
          </svg>
        </div>
        <input 
          type="email" 
          name="email" 
          placeholder="email"
          v-model="email"
          @blur="validateEmail"
          @keyup="validateEmail"
        />
      </div>
      <div v-if="emailError" class="error">
        <span>{{emailError}}</span>
      </div>
    </div>
    <div class="wrap password">
      <div class="input-wrap">
        <div class="icon">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
            <path d="M144 144v48H304V144c0-44.2-35.8-80-80-80s-80 35.8-80 80zM80 192V144C80 64.5 144.5 0 224 0s144 64.5 144 144v48h16c35.3 0 64 28.7 64 64V448c0 35.3-28.7 64-64 64H64c-35.3 0-64-28.7-64-64V256c0-35.3 28.7-64 64-64H80z"/>
          </svg>
        </div>
        <input 
          :type="passwordType" 
          name="password" 
          placeholder="password"
          v-model="password"
          @blur="validatePassword"
          @keyup="validatePassword"
        />
        <div 
          v-if="passwordType === 'text'" 
          @click="switchInputType" 
          class="pass-icon"
        >
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512">
            <path d="M288 32c-80.8 0-145.5 36.8-192.6 80.6C48.6 156 17.3 208 2.5 243.7c-3.3 7.9-3.3 16.7 0 24.6C17.3 304 48.6 356 95.4 399.4C142.5 443.2 207.2 480 288 480s145.5-36.8 192.6-80.6c46.8-43.5 78.1-95.4 93-131.1c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C433.5 68.8 368.8 32 288 32zM432 256c0 79.5-64.5 144-144 144s-144-64.5-144-144s64.5-144 144-144s144 64.5 144 144zM288 192c0 35.3-28.7 64-64 64c-11.5 0-22.3-3-31.6-8.4c-.2 2.8-.4 5.5-.4 8.4c0 53 43 96 96 96s96-43 96-96s-43-96-96-96c-2.8 0-5.6 .1-8.4 .4c5.3 9.3 8.4 20.1 8.4 31.6z"/>
          </svg>
        </div>
        <div 
          v-if="passwordType === 'password'" 
          @click="switchInputType" 
          class="pass-icon"
        >
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512">
            <path d="M38.8 5.1C28.4-3.1 13.3-1.2 5.1 9.2S-1.2 34.7 9.2 42.9l592 464c10.4 8.2 25.5 6.3 33.7-4.1s6.3-25.5-4.1-33.7L525.6 386.7c39.6-40.6 66.4-86.1 79.9-118.4c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C465.5 68.8 400.8 32 320 32c-68.2 0-125 26.3-169.3 60.8L38.8 5.1zM223.1 149.5C248.6 126.2 282.7 112 320 112c79.5 0 144 64.5 144 144c0 24.9-6.3 48.3-17.4 68.7L408 294.5c5.2-11.8 8-24.8 8-38.5c0-53-43-96-96-96c-2.8 0-5.6 .1-8.4 .4c5.3 9.3 8.4 20.1 8.4 31.6c0 10.2-2.4 19.8-6.6 28.3l-90.3-70.8zm223.1 298L373 389.9c-16.4 6.5-34.3 10.1-53 10.1c-79.5 0-144-64.5-144-144c0-6.9 .5-13.6 1.4-20.2L83.1 161.5C60.3 191.2 44 220.8 34.5 243.7c-3.3 7.9-3.3 16.7 0 24.6c14.9 35.7 46.2 87.7 93 131.1C174.5 443.2 239.2 480 320 480c47.8 0 89.9-12.9 126.2-32.5z"/>
          </svg>
        </div>
      </div>
      <div v-if="passwordError" class="error">
        <span>{{passwordError}}</span>
      </div>
    </div>
    <button type="submit" class="btn btn-custom">
      Login
    </button>
  </form>
</template>

<script>
  export default {
    data(){
      return{
        email: '',
        emailError: '',
        password: '',
        passwordError: '',
        passwordType: 'password',
        authorizedError: '',
      }
    },
    methods: {
      switchInputType(){
        this.passwordType = this.passwordType == 'password' ? 'text' : 'password'
      },
      validatePassword(){
        this.passwordError = this.password.length == 0 ? 'Password can not be empty.' : 
        (this.password.length >= 10 ? '' : 'Password must be at least 10 characters long.');
      },
      validateEmail(){
        this.emailError = this.email.length == 0 ? 'Email can not be empty.' :
        (this.checkEmail(this.email) ? '' : this.email + ' is not an email.');
      },
      checkEmail(email){
        const re = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        return re.test(email);
      },
      submitHandler(){
        this.validatePassword();
        this.validateEmail();

        if(this.emailError == '' && this.passwordError == ''){
          const authorized = checkUser(this.email, this.password);
          authorized ? this.$router.push("about") : 
          console.log("not authorized")
          //this.authorizedError = "your email or password was incorrect. Please try again."
        }
      }
    }
  };
</script>

<style lang="scss" scoped>
  @import "@/assets/styles/components/LoginForm.scss";
</style>