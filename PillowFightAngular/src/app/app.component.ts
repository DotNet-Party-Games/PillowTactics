import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GameroomService } from './shared/services/game/gameroom.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PillowFightAngular';
  constructor(private router:Router, private gamehub:GameroomService)
  {
  }

  ngOnInit()
  {
    this.router.navigate([""]);
    let a = this.gamehub.startconnection()
    console.log(a);
    setTimeout(() => {
        this.gamehub.startconnection
    }, 2000);
  }
}
