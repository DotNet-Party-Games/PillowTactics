import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ControlPanelService } from '../shared/services/ControlPanel/control-panel.service';
import { IPlayer } from '../shared/services/ControlPanel/player';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css']
})
export class ScoreboardComponent implements OnInit {
  playerList: IPlayer[] = [];

  constructor(private api: ControlPanelService) { }

  ngOnInit(): void {
    this.getPlayers(20);
  }

  getPlayers(numPlayers: number)
  {
    this.api.getPlayers(numPlayers).subscribe(
      (response) => {
        this.playerList = response;
      }
    )
  }

}
