import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm , FormControl, ReactiveFormsModule} from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    registration =  new FormGroup({
    realName:new FormControl(),
    email: new FormControl(),
    username: new FormControl(),
    password: new FormControl(),
    confirmPassword: new FormControl(),
  });
  constructor(private authService: AuthService) {     
    
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
