import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr'; 
import {IGameroom} from "./Gameroom";

@Injectable({
  providedIn: 'root'
})
export class GameroomService {

  rooms = new EventEmitter<any>();
  canJoin?:boolean = true;
  yourRoom = new EventEmitter<IGameroom>();
  myuserid?:number;

  private hubconnection?:HubConnection;

  constructor() { }
  //pillow-fight-game.azurewebsites.net
  startconnection=()=>{
    this.hubconnection= new HubConnectionBuilder().withUrl("https://pillow-fight-game.azurewebsites.net/gameHub").build();
    this.hubconnection.start().then(() => {
      console.log("Hub Connection Started");
      if(sessionStorage.getItem('userid')){
      this.SendUserId(parseInt(sessionStorage.getItem('userid')!))}
      console.log("sent userid");
    })
    .catch(err=> console.log("Error occured while starting connection: "+err))
  }
  SendUserId(userId:number){
    this.hubconnection?.invoke("SendUserId", userId).catch(err=>console.error(err));
  }

  ReceiveUserId(){
    this.hubconnection?.on("RecieveUserId", (userID)=> (this.myuserid=userID));
  };

  OnConnectedAsync() {
    this.hubconnection?.invoke("OnConnectedAsync")
      .catch(err=> console.error(err));
  }

  SendAvailableRooms() {
    this.hubconnection?.invoke("SendAvailableRooms").catch(err=>console.error(err));
  }
  ReceiveAvailableRooms(){
    console.log("getting available rooms");
    this.hubconnection?.on("ReceiveAvailableRooms", (roomIDs:any)=>{
      this.rooms.emit(roomIDs);
    })
  }

  SendNewRoomRequest(name:string){
    console.log("sent room request");
    this.hubconnection?.invoke("SendNewRoomRequest", name).catch(err=> console.error(err));
  }
  ReceiveNewRoomRequest(room:any){
    console.log("Making a new room");
    this.hubconnection?.on("ReceiveNewRoomRequest", (room)=> this.yourRoom.emit(room));
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
      else{
        this.yourRoom=request;
      }
    })
  }

  //in-game options
  SendActionOptions(charID:number, ){
    this.hubconnection?.invoke("SendActionOptions", charID, )
  }
  SendAvailableActions(charID:number){
    this.hubconnection?.invoke("SendAvailableActions", charID).catch((err) => console.error(err));
  }





}
