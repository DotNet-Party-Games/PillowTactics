import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { ICharacter } from '../shared/services/ControlPanel/character';
import { ControlPanelService } from '../shared/services/ControlPanel/control-panel.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  characters: ICharacter[] = [];

  constructor(private api: ControlPanelService, private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.getCharacters();
  }

  getCharacters()
  {
     this.api.getCharacters().subscribe(
      (response) => {
        this.characters = response;
      }
    );
  }

  deleteCharacter(characterId: number, characterName: string)
  {
    console.log("Deleting Character");
    this.api.deleteCharacter(characterId).subscribe(
      (response) => {
        alert(characterName + " has been deleted!");
        this.getCharacters();
      }
    );
  }

  goToCreate()
  {
    this.router.navigate(["create"]);
  }

  goToArena()
  {
    this.router.navigate(["arena"]);
  }
}