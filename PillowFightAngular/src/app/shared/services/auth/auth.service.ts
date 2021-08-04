import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from "rxjs/operators";
import { registerLocaleData } from '@angular/common';
import { User } from 'src/app/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authURL="apistring";
  headervalue="somevalue";
  constructor(private http:HttpClient) { }

  register(model:any){
    let headers = new HttpHeaders({
      "someheaders i need":this.headervalue
    })
    let options={headers:headers};
    return this.http.post(this.authURL+"create", model,options);
  }

  login(model:any) {
    return this.http.post(this.authURL+"login", model);
}
}
