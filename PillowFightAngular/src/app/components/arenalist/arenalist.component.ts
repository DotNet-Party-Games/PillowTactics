import { Component, OnInit, AfterViewChecked, HostListener, OnDestroy } from '@angular/core';
import { GameroomService } from 'src/app/shared/services/game/gameroom.service';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { IGameroom } from 'src/app/shared/services/game/Gameroom';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-arenalist',
  templateUrl: './arenalist.component.html',
  styleUrls: ['./arenalist.component.css']
})
export class ArenalistComponent implements OnInit {

  arenaname = new FormGroup({
    ArenaName: new FormControl("", [Validators.required])

  })
  arenas?:IGameroom[]= [];
  selectedArena?: IGameroom;
  joinable?:boolean = false;
  private arenasSub?:Subscription;
  private arenaSelectSub?:Subscription;
  listobserver={
    next:(x:any)=> {this.arenas=this.GameRoom.allrooms, console.log("arenalist component: list of rooms", this.arenas)},
    error:(err:any)=>console.log(err)
  }
  constructor(private GameRoom:GameroomService, private router:Router) { }

  ngOnInit(): void {
    const selectObserver={
      next:(x: any)=> {this.selectedArena=x; console.log(this.selectedArena)},
      error:(err: any)=> console.log(err)
    }

    this.GameRoom.SendAvailableRooms();
    this.arenasSub=this.GameRoom.rooms.subscribe(this.listobserver);
    this.arenaSelectSub=this.GameRoom.yourRoom.subscribe(selectObserver);
    console.log(this.selectedArena);
    console.log(this.arenas);
  }
  ngOnDestroy() {
    this.arenaSelectSub?.unsubscribe();
    this.arenasSub?.unsubscribe();
    console.log("Deleted");
  }

  addArena(f:FormGroup) {
    if(f.get("ArenaName")?.value==""){
        alert("Arena needs an Arena Name");
    }
    else{
    let name:string = f.get("ArenaName")?.value;
    this.GameRoom.SendNewRoomRequest(name);
    console.log("Player number 1 has connected")
    this.router.navigate(['/arena']);
    }
  }

  loadArena(id: string) {
    this.GameRoom.SendJoinRoomRequest(id);
    this.joinable=this.GameRoom.canJoin;
    if (this.joinable==false){
      alert("You cannot join this room");
    }
    else{
      this.arenaSelectSub?.unsubscribe();
      this.GameRoom.yourRoom.subscribe((room)=> this.selectedArena = room)
      console.log("loading room");
      console.log(this.selectedArena);
      this.router.navigate(['/arena']);
      console.log("Player number 2 has connected");
      sessionStorage.setItem("player1id",this.selectedArena!.Player1Id.toString());
      sessionStorage.setItem("player2id",  this.selectedArena!.Player2Id.toString());
      
    }
  }

  refreshArenaList(){
    console.log("refreshing gameroom");
    this.arenas=this.GameRoom.allrooms;
    this.arenasSub?.unsubscribe();
    this.GameRoom.SendAvailableRooms();
    this.GameRoom.rooms.subscribe(this.listobserver)
    this.arenas=this.GameRoom.allrooms
  }
}
