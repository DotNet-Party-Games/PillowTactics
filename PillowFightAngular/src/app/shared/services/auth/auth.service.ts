import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from "rxjs/operators";

import { User } from 'src/app/models/user';
import { environment } from 'src/environments/environment';
import { IRegister } from './Register';
import { ILogin } from './Login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authURL="apistring";
  headervalue="somevalue";
  constructor(private http:HttpClient) { }

  register(model:any){
    return this.http.post<IRegister>(this.authURL+"Register", model);
  }

  login(model:any) {
    return this.http.post<ILogin>(this.authURL+"Login", model);
}
}
