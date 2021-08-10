import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICharacter } from './character';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  //private url="https://pillow-fight-game.azurewebsites.net/api/ControlPanel";
  private url="http://localhost:5000/api/ControlPanel/Characters";

  constructor(private http:HttpClient) { }

  getCharacters() : Observable<ICharacter[]>
  {
    return this.http.get<ICharacter[]>(this.url + "/Characters", {withCredentials: true});
  }
}