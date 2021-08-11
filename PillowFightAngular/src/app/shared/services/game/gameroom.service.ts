import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr'; 
import {IGameroom} from "./Gameroom";

@Injectable({
  providedIn: 'root'
})
export class GameroomService {

  rooms: IGameroom[] = [];
  canJoin?:boolean = true;
  yourRoom?: IGameroom;


  private hubconnection:HubConnection | undefined;

  constructor() { }
  //pillow-fight-game.azurewebsites.net
  startconnection=()=>{
    this.hubconnection= new HubConnectionBuilder().withUrl("https://localhost:5000/gameHub").build();
    this.hubconnection.start().then(() => {
      console.log("Hub Connection Started");
    })
    .catch(err=> console.log("Error occured while starting connection: "+err))
  }

  OnConnectedAsync() {
    this.hubconnection?.invoke("OnConnectedAsync")
      .catch(err=> console.error(err));
  }

  SendAvailableRooms() {
    this.hubconnection?.invoke("SendAvailableRooms").catch(err=>console.error(err));
  }
  ReceiveAvailableRooms(){
    console.log("getting available rooms");
    this.hubconnection?.on("ReceiveAvailableRooms", (roomIDs)=> (this.rooms=roomIDs))
  }

  SendNewRoomRequest(name:string){
    this.hubconnection?.invoke("SendNewRoomRequest", name).catch(err=> console.error(err));
  }
  ReceiveNewRoomRequest(){
    console.log("Making a new room");
    this.hubconnection?.on("ReceiveNewRoomRequest", (room)=> this.yourRoom=room)
  }


  SendJoinRoomRequest(arenaID:string){
    this.hubconnection?.invoke("SendJoinRoomRequest",arenaID).catch(err=>console.error(err));
  }
  ReceiveJoinRoomRequest(){
    console.log("attempting to join room");
    this.hubconnection?.on("ReceiveJoinRoomRequest", (request) => {
      if (request== null){
        this.canJoin=false;
      }
    })
  }

  SendActionOptions(charID:number, ){
    this.hubconnection?.invoke("SendActionOptions", charID, )
  }
  SendAvailableActions(charID:number){
    this.hubconnection?.invoke("SendAvailableActions", charID).catch(err => console.error(err));
  }



}
