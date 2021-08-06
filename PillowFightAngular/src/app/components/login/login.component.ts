import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { ILogin } from 'src/app/shared/services/auth/Login';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
    //meaningless comment
    loginCred =  new FormGroup({
    Username: new FormControl(),
    Password: new FormControl()});

  constructor(private authService:AuthService) { 

  }

  ngOnInit(): void {
  }
  login(f:FormGroup){
    const loginObserver={
      next:(x: any)=> console.log('User logged in'),
      error:(err: any)=> console.log(err),
    }
    let tempLogin:ILogin = {
      Username:f.get("username")?.value,
      Password:f.get("password")?.value
    }

    this.authService.login(f.value).subscribe(loginObserver);
  }

}
