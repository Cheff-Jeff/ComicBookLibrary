export const CreateUser = (FNane, LName, Email, Pass, Salt, Id) => {
  return user = {
    firstName : FNane,
    lastName  : LName,
    email     : Email,
    password  : Pass,
    salt      : Salt,
    id        : Id,
  }
}

export const SignUp = (firstName, lastName, email, password) => {
  //api create user
  // api return id + isAdmin = false

}

export const Login = (email, password) => {
  // api send info
  // api get info
  
  // temp
  const user = {
    id: 1,
    isadmin: 0,
  }

  if(email == "admin@admin.com" && password == "adminadmin"){
    localStorage.setItem('user', JSON.stringify(user));
    return true;
  }
  else{
    return false
  }
}

export const Logout = () => {
  const user = JSON.parse(localStorage.getItem('user'));
  if(user !== null){
    localStorage.removeItem('user');
    return true;
  }
  else{
    return false;
  }
}