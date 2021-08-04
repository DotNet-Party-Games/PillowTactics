import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm , FormControl, Validators} from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registration:FormGroup;

  constructor(private authService: AuthService) {     
    this.registration =  new FormGroup({
    realName:new FormControl("", [Validators.required]),
    email: new FormControl("", [Validators.required]),
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
    confirmPassword: new FormControl("", [Validators.required]),
  })
}
  ngOnInit(): void {
  }
  onSubmit(f:NgForm){
    const registerObserver={
      next:(x: any)=> console.log('User Created'),
      error:(err: any)=> console.log(err),
    }
    this.authService.register(f.value).subscribe(registerObserver);

  }
}
