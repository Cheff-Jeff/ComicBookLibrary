import axios from "axios"
import { ref } from 'vue';

export const addItem = async (comicId) => {
  const data = {
    id: 0,
    comicId: comicId,
    userId: sessionStorage.getItem('user')
  }
  let result = null
  
  try {
    await axios.post(`${import.meta.env.VITE_API_LIBRARY}`, JSON.stringify(data), {
      headers: { 'Content-type': 'application/json'}
    }).then((response) => {
      result = {
        code: response.status
      }
    }) 
  } catch (error) {
    result = {
      code: error.response.status,
      error: error.response.data
    }
  }

  return result
}

export const removeItem = async (id) => {
  let result = null
  try {
    await axios.delete(`${import.meta.env.VITE_API_LIBRARY}/${id}`, {
      headers: { 'Content-type': 'application/json'}
    }).then((response) => {
      result = {
        code: response.status
      }
    }) 
  } catch (error) {
    result = {
      code: error.response.status,
      error: error.response.data
    }
  }

  return result
}

export const getUserLibrary = (userId) => {
  let result = ref(null);

  const getData = async () => {
    await axios.get(`${import.meta.env.VITE_API_LIBRARY}/${userId}`, {
      headers: { 'Content-type': 'application/json'}
    }).then(
      response => (result.value = response.data)
    )
  }

  getData()

  return result
}