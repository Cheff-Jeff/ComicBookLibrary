import axios from "axios";

export const checkUser = async (emailInput, passwordInput) => {
  const data = {
    email: emailInput,
    password: passwordInput
  }
  let result = null

  try {
    await axios.post(`${import.meta.env.VITE_API_USERS}/AdminLogin`, data, {
      headers: { 'Content-type': 'application/json'}
    }).then((response) => {
      result = response;
    }) 
  }catch (error) {
    console.log(error);
  }
  
  if(result !== null)
  {
    sessionStorage.setItem('userIsAdmin', true);
    return true;
  }
  else 
  {
    return false;
  }
}

export const Logout = () => {
  const user = JSON.parse(sessionStorage.getItem('userIsAdmin'))
  if(user !== null){
    sessionStorage.removeItem('userIsAdmin');
    return true;
  }
  else{
    return false;
  }
}

export const checkRoute = () => {
  const user = JSON.parse(sessionStorage.getItem('userIsAdmin'));
  switch (user){
    case true:
      return true
      break;
    default:
      return false
  }
}

export const checkRouteItem = async (url) => {
  let result = null;
  const user = JSON.parse(sessionStorage.getItem('userIsAdmin'));
  switch (user){
    case true:
      try {
        await axios.get(url).then(result = true);
      } catch (error) {
        console.log(error);
        result = false;
      }
      return result
      break;
    default:
      return false
  }
}