import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    Username: new FormControl('', [Validators.required]),
    Password: new FormControl('', [Validators.required])
  });
  success:boolean=false;
  constructor(private authService:AuthService, private router:Router) { 

  }

  ngOnInit(): void {
  }

  login(f:FormGroup){
    let tempLogin:ILogin = {
      username: f.get("Username")?.value,
      password:this.loginCred.get("Password")?.value
    }

    this.authService.login(tempLogin).subscribe(loginObserver=>
      {console.log(loginObserver);
        if (loginObserver){
          sessionStorage.setItem('userid', loginObserver.userId!.toString());
          sessionStorage.setItem('username', loginObserver.userName!.toString());
          console.log("Logged in");
          this.router.navigate([''])
        }
    });
  }
}
