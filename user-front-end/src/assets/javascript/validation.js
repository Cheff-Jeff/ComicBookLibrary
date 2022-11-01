const reName = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]*$/;
const reEmail = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
const reTitle = /^[a-zA-Z0-9_ #-]*$/;

export const validateName = (name) => {
  return reName.test(name);
}
export const validateTitle = (title) => {
  return reTitle.test(title);
}
export const validateEmail = (email) => {
  return reEmail.test(email);
}