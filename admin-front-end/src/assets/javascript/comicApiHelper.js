import axios from "axios";

const requestPost = async (data) => {
  let result = null

  await axios.post(`${import.meta.env.VITE_API_COMICS_URL}`, 
    data, {
      headers: { 'Content-type': 'multipart/form-data'}
    }
  ).then((response) => {
    result = response;
  }).catch((error) => {
    result = error
    console.log(error);
  })

  return result
}

const requestPut = async (data, destination) => {
  let result = null
  await axios.put(`${import.meta.env.VITE_API_COMICS_URL}/${destination}`,
    data, {
      headers: {'Content-type': 'multipart/form-data'}
    }
  ).then((response) => {
    result = response;
  }).catch((error) => {
    result = error
  })

  return result
}

const requestDelete = async (destination) => {
  let result = null
  console.log(`${import.meta.env.VITE_API_COMICS_URL}/${destination}`);
  await axios.delete(`${import.meta.env.VITE_API_COMICS_URL}/${destination}`, {
      headers: {'Content-Type': 'application/json'},
    }
  ).then((response) => {
    result = response;
  }).catch((error) => {
    result = error
  })

  return result
}

export const postComic = async (comic)=>{
  try {
    return await requestPost(comic)
  } catch (error) {
    return error
  }
}

export const putComic = async (comic, id)=>{
  try {
    return await requestPut(comic,id)
  } catch (error) {
    console.log(error);
  }
}

export const deleteComic = async (id)=>{
  try {
    console.log(id);
    return await requestDelete(id)
  } catch (error) {
    return error
  }
}