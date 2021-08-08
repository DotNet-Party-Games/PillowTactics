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
      name: "Bob",
      class: "Knight",
      strength: 5,
      dexterity: 5,
      constitution: 5,
      intelligence: 5,
      wisdom: 5,
      weapon: {
        name: "Bob's Sword",
        attack: 5,
        range: 5
      },
      armor: {
        name: "Bob's Armor",
        defense: 5
      }
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
