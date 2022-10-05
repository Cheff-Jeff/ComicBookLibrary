import axios from "axios";

export const routGaurd = async (url) => {
  let result = null;
  
  await axios.get(url).then(response => (
    result = response.data.length
  ));

  return result;
}

export const CheckLogin = () => {
  const user = JSON.parse(localStorage.getItem('user'));
  if(user !== null)
  {
    return true
  }
  else
  {
    return false
  }
}