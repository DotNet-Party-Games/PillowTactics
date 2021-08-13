import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { CreatecharacterComponent } from './createcharacter/createcharacter.component';
import { ArenaComponent } from './arena/arena.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ArenalistComponent } from './components/arenalist/arenalist.component';
import { AuthModule } from '@auth0/auth0-angular';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    CreatecharacterComponent,
    ArenaComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavbarComponent,
    ArenalistComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      {path: "", component: HomeComponent},
      {path: "profile", component: ProfileComponent},
      {path: "create", component: CreatecharacterComponent},
      {path: "arena", component: ArenaComponent},
      {path:"login", component: LoginComponent},
      {path:"register", component:RegisterComponent},
      {path:"arenalist", component:ArenalistComponent},
      {path:"arena", component:ArenaComponent}
    ]),
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
