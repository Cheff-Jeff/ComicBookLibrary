import { HubConnectionBuilder } from "@microsoft/signalr"

export class ComicHub {
  constructor(){
    console.log('in hub')
    //maak verbinding met de hub
    this.conn = new HubConnectionBuilder()
      .withUrl(`${import.meta.env.VITE_API_SIGNALR}`)
      .build()

    this.connect();

    this.conn.on("RecivePopular", (comics)=>{
      //maak een niew event waar naar geluister kan worden.
      localStorage.setItem('popular', comics)
      window.dispatchEvent(PopularComics)
    })
 
    this.conn.on("Close", ()=>{
      this.conn.stop()
    })

    //Voer event uit
    const PopularComics = new Event('PopularComics')
  }

  async connect() {
    try {
      await this.conn.start()
      console.log("SignalR Connected.")
    } catch (error) {
      console.log(error);
    }
  }

  addNewPopularity(id){
    this.conn.invoke("AddPopularity", id).catch(function(err) {
      return console.error(err.toString())
    })
  }

  removePopularity(id){
    this.conn.invoke("RemovePopularity", id).catch(function(err) {
      return console.error(err.toString())
    })
  }
}