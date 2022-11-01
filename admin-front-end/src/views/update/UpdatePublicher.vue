<script setup>
  import { useRoute } from 'vue-router';
  import Header from '@/components/Header.vue';
  import PublicherForm from '@/components/forms/PublicherForm.vue';
  import { useFetch } from '@/assets/javascript/fetchNewComics';

  const route = useRoute();
  const publicher = useFetch(`${import.meta.env.VITE_API_PUBLICHERS_URL}/${route.params.id}`);
</script>

<template>
  <Header></Header>
  <div class="container" v-if="publicher">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <PublicherForm 
            @submit='redirect' 
            :Value="publicher.name" 
            :Id="publicher.id" 
            apiType="put"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    redirect() {
      this.$router.push({name: 'Publichers'});
    }
  }
}
</script>