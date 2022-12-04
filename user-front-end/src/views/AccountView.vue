<script setup>
  import SideBar from "@/components/SideBar.vue";
  import Library from "@/components/Library.vue";
  import Account from "@/components/Account.vue";
  import { Logout } from "@/assets/javascript/authentication";
</script>

<template>
  <div class="account-wrap">
    <div class="container-fluid customLeft">
      <div class="row">
        <div class="col-md-1">
          <SideBar 
            @library="showLibrary" 
            @account="showAccount"
            @logout="signOff"
          />
        </div>
        <div class="col-md-11">
          <div class="details-wrap" v-auto-animate>
            <Library v-if="library"/>
            <Account v-if="account"/>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      library: 'open',
      account: ''
    }
  },
  methods: {
    showLibrary() {
      this.account = ''
      this.library = 'open'
    },
    showAccount(){
      this.account = 'open'
      this.library = ''
    },
    signOff(){
      Logout()
      this.$router.push({name: 'home'})
    }
  },
}
</script>

<style lang="scss">
  @import '../assets/styles/pages/Account.scss';
</style>