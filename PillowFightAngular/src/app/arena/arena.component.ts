import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-arena',
  templateUrl: './arena.component.html',
  styleUrls: ['./arena.component.css']
})
export class ArenaComponent implements OnInit {
  grid:number[]

  constructor() { 
    this.grid = new Array(144)
    for (var i = 0; i < this.grid.length; i++)
    {
      this.grid[i] = i;
    }
  }

  ngOnInit(): void {
  }

  generateArena()
  {

  }

}
