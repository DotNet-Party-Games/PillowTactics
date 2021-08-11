import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IRegister } from './Register';
import { ILogin } from './Login';
import { Observable } from 'rxjs';
import { ILogout } from './Logout';
import {ILoggedInUser} from './LoggedInUser'
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loggedInUser:ILoggedInUser ={
    userId:0,
    userName:"",
    password:"",
    wins:0,
    losses:0,
    email:""
  }
  private authURL="https://pillow-fight-game.azurewebsites.net/api/Login";
  private controlURL = "https://pillow-fight-game.azurewebsites.net/api/ControlPanel";
  constructor(private http:HttpClient) { }

  register(model:any) : Observable<IRegister>{
    return this.http.post<IRegister>(this.authURL+"/Register", model);
  }

  login(model:any): Observable<ILoggedInUser> {
    return this.http.post<ILogin>(this.authURL+"/Login", model);
  }

  logout(){
      return this.http.get(this.controlURL+"/Logout", { withCredentials: true });
  }
}
