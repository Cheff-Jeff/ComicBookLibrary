import axios from "axios";

export const uploadImage = (img) => {
  console.log(img);
  const formdata = new FormData()
  formdata.append('file', img)
  console.log(formdata);
  const comic = {
    Id: 0,
    Title: "string",
    Description: "string",
    Image: "string",
    PublisherId: 2,
    Publisher: {
      Id: 0,
      Name: "string"
    },
    CoverArtistId: 2,
    CoverArtist: {
      Id: 0,
      Name: "string"
    },
    WriterId: 2,
    Writer: {
      Id: 0,
      Name: "string"
    },
    ArtistId: 2,
    Artist: {
      Id: 0,
      Name: "string"
    },
    ImageFile: img
  }

  axios.post(`${import.meta.env.VITE_API_COMICS_URL}`,
    comic,{
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    }
  ).catch((error) => {
    console.log(error)
  })
}