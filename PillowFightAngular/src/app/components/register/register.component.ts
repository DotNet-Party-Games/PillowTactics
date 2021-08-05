import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm , FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
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
    Password: new FormControl("", [Validators.required])
  });
  constructor(private authService: AuthService) {     
    
}
  ngOnInit(): void {
  }
  
  registerPlayer(f:FormGroup)
  {
    const registerObserver={
      next:(x: any)=> console.log('User logged in'),
      error:(err: any)=> console.log(err),
    }
    let tempPlayer:IRegister = {

      Email: f.get("email")?.value,
      Username:f.get("username")?.value,
      Password:f.get("password")?.value
    }
    this.authService.register(tempPlayer).subscribe(registerObserver);
  }
}
