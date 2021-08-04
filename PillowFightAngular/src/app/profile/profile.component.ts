import { Component, OnInit } from '@angular/core';
import { ICharacter } from "./character";
import { Router } from "@angular/router";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  character:ICharacter

  constructor(private router:Router) 
  {
    this.character = {
      name: "Bob"
    }
  }

  ngOnInit(): void {
  }

  goToCreate()
  {
    this.router.navigate(["/create"]);
  }

  goToEdit()
  {
    this.router.navigate(["/edit"]);
  }

  goToArena()
  {
    this.router.navigate(["/arena"]);
  }

}
