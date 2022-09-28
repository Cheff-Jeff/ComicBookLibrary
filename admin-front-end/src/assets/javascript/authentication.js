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