import { HubConnectionBuilder } from "@microsoft/signalr"

export class ComicHub {
  constructor(){
    console.log('in hub')
    //maak verbinding met de hub
    this.conn = new HubConnectionBuilder()
      .withUrl(`${import.meta.env.VITE_API_SIGNALR}`)
      .build()
    
    this.conn.onclose(async () => {
      await this.connect();
    })

    this.connect();

    this.conn.on("RecivePopular", (comics)=>{
      //maak een niew event waar naar geluister kan worden.
      localStorage.setItem('popular', comics)
      window.dispatchEvent(PopularComics)
    })

    this.conn.on("Close", ()=>{
      this.conn.stop()
    })

    //const NewChat = new Event('NewChat')
  }

  async connect() {
    try {
      await this.conn.start()
      console.log("SignalR Connected.")
    } catch (error) {
      console.log(error);
    }
  }
}