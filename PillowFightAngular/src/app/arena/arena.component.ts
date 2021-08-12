import { Component, OnInit } from '@angular/core';
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
  nextplayer?:boolean;
  roominfo?:IGameroom;
  

  constructor(private gamehub:GameroomService) { 
    this.grid = new Array(144)
    for (var i = 0; i < this.grid.length; i++)
    {
      this.grid[i] = i;
    }
  }

  ngOnInit(): void {

  }

  newfight(){
    this.nextplayer=false;

  }

  moveup(){
  }

}
