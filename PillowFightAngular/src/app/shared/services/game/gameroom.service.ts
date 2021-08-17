import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr'; 
import {IGameroom} from "./Gameroom";

@Injectable({
  providedIn: 'root'
})
export class GameroomService {

  rooms = new EventEmitter<any>();
  allrooms: IGameroom[]=[];
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
    this.hubconnection?.on("RecieveUserId", (userID)=> (this.myuserid=userID));
    this.hubconnection?.on("ReceiveAvailableRooms", (roomIDs:any)=>{console.log("got all rooms"); console.log(roomIDs); this.allrooms=roomIDs; this.rooms.emit(roomIDs); })
    this.hubconnection?.on("ReceiveNewRoomRequest", (room)=> {console.log("Made a new room"); this.allrooms.push(room); this.yourRoom.emit(room); this.SendAvailableRooms();});
    this.hubconnection?.on("ReceiveJoinRoomRequest", (request) => {
      if (request== null){
        this.canJoin=false;
      }
      else{
        this.yourRoom.emit(request);
      }
    });
    this.hubconnection?.on("ReceiveAction", (res)=> {console.log(res.Character)})
  }
  SendUserId(userId:number){
    this.hubconnection?.invoke("SendUserInfo", userId).catch(err=>console.error(err));
  }

  ReceiveUserId(){
    this.hubconnection?.on("RecieveUserId", (userID)=> (this.myuserid=userID));
  };

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
  SendActionOptions(charID:number, action:string){
    this.hubconnection?.invoke("SendActionOptions", charID, action ).catch((err) => console.log(err));
  }
  
  SendAvailableActions(charID:number){
    this.hubconnection?.invoke("SendAvailableActions", charID).catch((err) => console.log(err));
  }

  SendAction(action:string){
    this.hubconnection?.invoke("SendAction", action).catch((err)=>console.log(err));
  }
  SendLeaveRoomRequest(){
    this.hubconnection?.invoke("SendLeaveRoomRequest").catch((err)=>console.log(err));
  }





}
