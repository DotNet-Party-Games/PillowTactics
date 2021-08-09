import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class GameroomService {

  private hubconnection:signalR.HubConnection | undefined;

  constructor() { }

  startconnection=()=>{
    this.hubconnection= new signalR.HubConnectionBuilder().withUrl("https://myappurl/chathub").build();
    this.hubconnection.start().then(() => {
      console.log("Hub Connection Started");
    })
    .catch(err=> console.log("Error occured while starting connection: "+err))
  }

  OnConnectedAsync() {
    this.hubconnection?.invoke("OnConnectedAsync")
      .catch(err=> console.error(err));
  }

  OnConnectedAsyncListener(){
    this.hubconnection?.on("askServerResponse", (someText)=> {
      console.log(someText);
    })
  }

  SendNewRoomRequest(){
    this.hubconnection?.invoke("SendNewRoomRequest")

  }

  SendJoinRoomRequest(arenaID:string){
    this.hubconnection?.invoke("SendJoinRoomRequest",arenaID)
  }
}
