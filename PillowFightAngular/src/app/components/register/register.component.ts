import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm , FormControl, ReactiveFormsModule, Validators, ValidatorFn, ValidationErrors} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { IRegister } from 'src/app/shared/services/auth/Register';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  //port: 31537?

    registration =  new FormGroup({
    Email: new FormControl("", [Validators.required]),
    Username: new FormControl("", [Validators.required]),
    Password: new FormControl("", [Validators.required]),
    //confirmPassword: new FormControl("", [Validators.required])
    }
  );
  constructor(private authService: AuthService, private router:Router) {     
    
}
  ngOnInit(): void {
  }
  

  registerPlayer(f:FormGroup)
  {
    const registerObserver={
      next:(x: any)=> alert('User registered, please log in'),
      error:(err: any)=> console.log(err),
    }
    console.log(f.value)
    let tempPlayer:IRegister = {
      Email: this.registration.get("Email")?.value,
      Username:this.registration.get("Username")?.value,
      Password:this.registration.get("Password")?.value
    }
    this.authService.register(tempPlayer).subscribe(registerObserver => location.reload());
  }
}
