import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  constructor(private authService:AuthService) { 

  }

  ngOnInit(): void {
  }
  onsubmit(f:NgForm){
    const loginObserver={
      next:(x: any)=> console.log('User logged in'),
      error:(err: any)=> console.log(err),
    }
    this.authService.login(f.value).subscribe(loginObserver);
  }

}
