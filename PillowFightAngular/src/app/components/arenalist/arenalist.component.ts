import { Component, OnInit } from '@angular/core';
import { GameroomService } from 'src/app/shared/services/game/gameroom.service';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { IGameroom } from 'src/app/shared/services/game/Gameroom';

@Component({
  selector: 'app-arenalist',
  templateUrl: './arenalist.component.html',
  styleUrls: ['./arenalist.component.css']
})
export class ArenalistComponent implements OnInit {

  arenaname = new FormGroup({
    ArenaName: new FormControl("", [Validators.required])

  })
  arenas:IGameroom[]= [];
  selectedArena?: string;
  joinable?:boolean = false;

  constructor(private GameRoom:GameroomService) { }

  ngOnInit(): void {
/*     this.GameRoom.startconnection();
    this.GameRoom.OnConnectedAsync();
    this.selectedArena = this.GameRoom.yourRoom?.Id;
    this.GameRoom.SendAvailableRooms();
    this.arenas=this.GameRoom.rooms; */
  }

  addArena(f:FormGroup) {
    if(f.get("ArenaName")?.value==""){
        alert("Arena needs an Arena Name");
    }
    let name:string = f.get("ArenaName")?.value;
    this.GameRoom.SendNewRoomRequest(name);
  }

  loadArena(id: string) {
    this.GameRoom.SendJoinRoomRequest(id);
    this.joinable=this.GameRoom.canJoin;
    if (this.joinable==false){
      alert("You cannot join this room");
    }
    
  }
}
