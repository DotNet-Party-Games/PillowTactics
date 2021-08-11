import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { ICharacter } from '../shared/services/profile/character';
import { ProfileService } from '../shared/services/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  character: ICharacter[] = [];

  constructor(private api:ProfileService) 
  { }

  ngOnInit(): void {
    this.api.getCharacters().subscribe(
      (response) => {
        this.character = response;
      }
    );
  }

  getCharacters()
  {
    this.api.getCharacters().subscribe(
      (response) => {
        this.character = response;
      }
    );
  }
}