import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormControl, FormGroup } from '@angular/forms';
import { ControlPanelService } from '../shared/services/ControlPanel/control-panel.service';
import { IEmptyCharacter } from '../shared/services/ControlPanel/emptycharacter';

@Component({
  selector: 'app-createcharacter',
  templateUrl: './createcharacter.component.html',
  styleUrls: ['./createcharacter.component.css']
})
export class CreatecharacterComponent implements OnInit {
  userId: number = parseInt(sessionStorage.getItem("userid")!);

  blankGroup = new FormGroup({
    name: new FormControl(),
    characterClass: new FormControl(),
    weaponId: new FormControl(),
    armorId: new FormControl()
  });

  constructor(private api: ControlPanelService, private router: Router) { }

  ngOnInit(): void {
  }

  createCharacter(blankGroup: FormGroup)
  {
    let newBlankCharacter: IEmptyCharacter = {
      userId: this.userId,
      characterId: 0,
      name: blankGroup.get("name")!.value,
      characterClass: blankGroup.get("characterClass")!.value,
      weaponId: blankGroup.get("weaponId")!.value,
      armorId: blankGroup.get("armorId")!.value
    }

    if (!newBlankCharacter.name || !newBlankCharacter.characterClass || !newBlankCharacter.weaponId || !newBlankCharacter.armorId)
    {
      alert("Please fill in all fields.");
      return;
    }

    this.api.createCharacter(newBlankCharacter).subscribe(
      (response) => {
        console.log(response);
        newBlankCharacter.characterId = response.id;
        console.log("character Id: " + newBlankCharacter.characterId);
        this.api.equipCharacter(newBlankCharacter).subscribe(
          (response) => {
            console.log(response);
          }
        );
        alert(newBlankCharacter.name + " has been created!");
      }
    );
  }
}
