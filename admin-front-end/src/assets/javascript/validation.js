const reName = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]*$/;
const reEmail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

export const validateName = (name) => {
  return reName.test(name);
}

export const validateEmail = (email) => {
  return reEmail.test(email);
}