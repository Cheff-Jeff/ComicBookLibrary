import axios from "axios";

export const routGaurd = async (url) => {
  let result = null;
  console.log(url)
  try{
    await axios.get(url).then(result = true);
  }
  catch (error){
    console.log(error);
    result = false;
  }

  return result;
}

export const CheckLogin = () => {
  const user = JSON.parse(sessionStorage.getItem('user'));
  if(user !== null)
  {
    return true
  }
  else
  {
    return false
  }
}