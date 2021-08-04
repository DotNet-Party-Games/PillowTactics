import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authURL="apistring";
  constructor(private http:HttpClient) { }

  login(model:any){
    return this.http.post(this.authURL + "login", model).pipe(
      map(response : any){
        const user=response;
        if (user.result) {
          localStorage.setItem("token", user.token);
        }
      }
    )
  }
}
