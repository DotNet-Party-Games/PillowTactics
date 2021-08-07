import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { CreatecharacterComponent } from './createcharacter/createcharacter.component';
import { EditcharacterComponent } from './editcharacter/editcharacter.component';
import { ArenaComponent } from './arena/arena.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    CreatecharacterComponent,
    EditcharacterComponent,
    ArenaComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      {path: "", component:HomeComponent},
      {path: "profile", component: ProfileComponent},
      {path: "create", component: CreatecharacterComponent},
      {path: "edit", component: EditcharacterComponent},
      {path: "arena", component: ArenaComponent},
      {path:"login", component: LoginComponent},
      {path:"register", component:RegisterComponent}
    ]),
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
