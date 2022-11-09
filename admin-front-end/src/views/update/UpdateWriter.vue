<script setup>
  import { useRoute } from 'vue-router';
  import Header from '../../components/Header.vue';
  import WriterForm from '../../components/forms/WriterForm.vue'
  import { useFetch } from '../../assets/javascript/fetchNewComics';

  const route = useRoute();
  const writer = useFetch(`${import.meta.env.VITE_API_WRITHERS_URL}/${route.params.id}`);
</script>

<template>
  <Header></Header>
  <div class="container" v-if="writer">
    <div class="row">
      <div class="col-12">
        <div class="inner">
          <WriterForm 
            @done='redirect' 
            :Value="writer.name" 
            :Id="writer.id" 
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
      this.$router.push({name: 'Writers'});
    }
  }
}
</script>