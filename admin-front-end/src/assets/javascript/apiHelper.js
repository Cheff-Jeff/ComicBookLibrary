import axios from "axios";

const request = async (data, destination) => {
  let result = null;
  await axios({
    headers: {'Content-Type': 'application/json'},
    method: 'post',
    url: destination,
    data: JSON.stringify(data)
  }).then((response) => {
    result = response;
  }).catch((error) => {
    console.log(error)
  })

  return result;
}

const requestPut = async (data, destination) => {
  let result = null;
  await axios({
    headers: {'Content-Type': 'application/json'},
    method: 'put',
    url: destination,
    data: JSON.stringify(data)
  }).then((response) => {
    result = response;
  }).catch((error) => {
    console.log(error)
  })

  return result;
}

const requestDelete = async (destination) => {
  let result = null;
  await axios({
    headers: {'Content-Type': 'application/json'},
    method: 'delete',
    url: destination,
  }).then((response) => {
    result = response;
  }).catch((error) => {
    console.log(error)
  })

  return result;
}

export const postRequest = async (name, destination) => {
  const data = {
    'id': 0,
    'name': name
  }

  switch (destination) {
    case 'Artists':
      try {
        return await request(data, `${import.meta.env.VITE_API_ARTISTS_URL}`)
      } catch (error) {
        return error
      }
      break;
    case 'Writers':
      try {
        return await request(data, `${import.meta.env.VITE_API_WRITHERS_URL}`)
      } catch (error) {
        return error
      }
      break;
    case 'Publichers':
      try {
        return await request(data, `${import.meta.env.VITE_API_PUBLICHERS_URL}`)
      } catch (error) {
        return error
      }
      break;
    default:
      return {
        result: false,
        error: 'Bad destination'
      };
      break;
  }
}

export const putRequest = async (data, destination) => {
  switch (destination) {
    case 'Artists':
      try {
        return await requestPut(data, `${import.meta.env.VITE_API_ARTISTS_URL}/${data.id}`)
      } catch (error) {
        return error
      }
      break;
    case 'Writers':
      try {
        return await requestPut(data, `${import.meta.env.VITE_API_WRITHERS_URL}/${data.id}`)
      } catch (error) {
        return error
      }
      break;
    case 'Publichers':
      try {
        return await requestPut(data, `${import.meta.env.VITE_API_PUBLICHERS_URL}/${data.id}`)
      } catch (error) {
        return error
      }
      break;
    default:
      return {
        result: false,
        error: 'Bad destination'
      };
      break;
  }
}

export const deleteRequest = async (id, destination) => {
  switch (destination) {
    case 'Artists':
      try {
        return await requestDelete(`${import.meta.env.VITE_API_ARTISTS_URL}/${id}`)
      } catch (error) {
        return error
      }
      break;
    case 'Writers':
      try {
        return await requestDelete(`${import.meta.env.VITE_API_WRITHERS_URL}/${id}`)
      } catch (error) {
        return error
      }
      break;
    case 'Publichers':
      try {
        return await requestDelete(`${import.meta.env.VITE_API_PUBLICHERS_URL}/${id}`)
      } catch (error) {
        return error
      }
      break;
    default:
      return {
        result: false,
        error: 'Bad destination'
      };
      break;
  }
}