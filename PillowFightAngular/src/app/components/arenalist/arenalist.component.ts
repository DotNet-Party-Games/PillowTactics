import { Component, OnInit } from '@angular/core';
import { GameroomService } from 'src/app/shared/services/game/gameroom.service';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-arenalist',
  templateUrl: './arenalist.component.html',
  styleUrls: ['./arenalist.component.css']
})
export class ArenalistComponent implements OnInit {

  arenaname = new FormGroup({
    ArenaName: new FormControl("", [Validators.required])

  })
  arenas:string[] = [];
  selectedArena?: string;
  constructor(private GameRoom:GameroomService) { }

  ngOnInit(): void {
  }

  addArena(f:FormGroup) {
    let name:string = f.get("ArenaName")?.value;
    this.GameRoom.SendNewRoomRequest();
  }

  loadArena(id: string) {
    this.GameRoom.SendJoinRoomRequest(id);
  }
}
