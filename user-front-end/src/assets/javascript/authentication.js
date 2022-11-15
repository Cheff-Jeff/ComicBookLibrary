import axios from "axios"

export const SignUp = async (firstName, lastName, email, password) => {
  let result = null
  const user = {
    id: 0,
    isAdmin: false,
    firstName: firstName,
    lastName: lastName,
    email: email,
    password: password,
    salt: "string"
  }
  
  try {
    await axios.post(`${import.meta.env.VITE_API_USERS}`, user, {
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

export const Login = async (email, password) => {
  let result = null
  const user = {
    email: email,
    password: password
  }
  try {
    await axios.post(`${import.meta.env.VITE_API_USERS}/Login`, user, {
      headers: { 'Content-type': 'application/json'}
    }).then((response) => {
      result = {
        code: response.status,
        data: response.data
      }
    }) 
  } catch (error) {
    result = {
      code: error.response.status,
      error: error.response.data
    }
  }

  if(result.code == 200){
    sessionStorage.setItem('user', result.data.id);
  }

  return result
}

export const Logout = () => {
  const user = JSON.parse(sessionStorage.getItem('user'));
  if(user !== null){
    sessionStorage.removeItem('user');
    return true;
  }
  else{
    return false;
  }
}