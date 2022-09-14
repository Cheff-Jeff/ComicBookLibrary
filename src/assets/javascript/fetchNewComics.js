import { ref } from 'vue';

export const useFetch = (url) => {
  const data = ref(null);

  const fetchData = async () => {
    data.value = await fetch(url)
      .then((r) => r.json());

    localStorage.setItem('newComics',JSON.stringify(data.value));
  }

  fetchData();

  return data;
}

export const useCache = (url) => {
  let data = ref(null);

  const fetchCache = () => {
    if(localStorage.getItem('newComics') !== null){
      data.value = JSON.parse(localStorage.getItem('newComics'));
    }
    else{
      data = useFetch(url);
    }
  }

  fetchCache();

  return data;
}