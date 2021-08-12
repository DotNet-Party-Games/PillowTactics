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

  deleteCharacter(characterId: number)
  {
    console.log("Deleting Character");
    this.api.deleteCharacter(characterId).subscribe(
      (response) => {
        console.log("Character Deleted: " + response);
      }
    );

    this.getCharacters();
  }

  goToCreate()
  {
    this.router.navigate(["create"]);
  }

  goToEdit()
  {
    this.router.navigate(["edit"]);
  }

  goToArena()
  {
    this.router.navigate(["arena"]);
  }
}