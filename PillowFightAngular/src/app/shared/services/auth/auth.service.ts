import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IRegister } from './Register';
import { ILogin } from './Login';
import { Observable } from 'rxjs';
import { ILogout } from './Logout';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authURL="https://pillow-fight-game.azurewebsites.net/api/Login";
  private controlURL = "https://pillow-fight-game.azurewebsites.net/api/ControlPanel";
  constructor(private http:HttpClient) { }

  register(model:any) : Observable<IRegister>{
    let a=this.http.post<IRegister>(this.authURL+"/Register", model);
    console.log(JSON.stringify(model));
    return a;
  }

  login(model:any): Observable<ILogin> {
    return this.http.post<ILogin>(this.authURL+"/Login", model);
  }

  logout(){
      return this.http.get(this.controlURL+"/Logout");
  }
}
