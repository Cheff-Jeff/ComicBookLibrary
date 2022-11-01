import axios from "axios";

export const checkUser = (email, password) => {
  /*
  *api call to check user input
    return true/false
  * set user localstorege
  *return true/false
  */
  if(email == "admin@admin.com" && password == "adminadmin")
  {
    localStorage.setItem('userIsAdmin', true);
    return true;
  }
  else 
  {
    return false;
  }
}

export const Logout = () => {
  const user = JSON.parse(localStorage.getItem('userIsAdmin'))
  if(user !== null){
    localStorage.removeItem('userIsAdmin');
    return true;
  }
  else{
    return false;
  }
}

export const checkRoute = () => {
  const user = JSON.parse(localStorage.getItem('userIsAdmin'));
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
  const user = JSON.parse(localStorage.getItem('userIsAdmin'));
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