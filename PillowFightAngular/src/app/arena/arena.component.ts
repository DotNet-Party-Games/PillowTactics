import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IGameroom } from '../shared/services/game/Gameroom';
import { GameroomService } from '../shared/services/game/gameroom.service';

@Component({
  selector: 'app-arena',
  templateUrl: './arena.component.html',
  styleUrls: ['./arena.component.css']
})
export class ArenaComponent implements OnInit {
  grid:number[]
  characters?:any[];
  winner?:string;
  nextplayer?:boolean= false;
  roominfo?:IGameroom;
  character1Pos:number= 65;
  character2Pos:number = 66
  clickmove:boolean=false;
  
  moveAmount=  new FormGroup({
    Spaces: new FormControl("", [Validators.required]),
    Direction: new FormControl("", [Validators.required]),
  })
  constructor(private gamehub:GameroomService) { 
    this.grid = new Array(144)
    for (var i = 0; i < this.grid.length; i++)
    {
      this.grid[i] = i;
    }
  }

  ngOnInit(): void {

  }

  move(){
    this.clickmove=true;
  }

  movecalculator(x:number, y:number){
      this.gamehub.SendAction("move");
  }

  leaveRoom(){
    console.log("leaving room");
    this.gamehub.SendLeaveRoomRequest();
    sessionStorage.removeItem("player1id");
    sessionStorage.removeItem("player2id");
  }
}
