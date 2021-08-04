import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { CreatecharacterComponent } from './createcharacter/createcharacter.component';
import { EditcharacterComponent } from './editcharacter/editcharacter.component';
import { ArenaComponent } from './arena/arena.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    CreatecharacterComponent,
    EditcharacterComponent,
    ArenaComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: "profile", component: ProfileComponent},
      {path: "create", component: CreatecharacterComponent},
      {path: "edit", component: EditcharacterComponent},
      {path: "arena", component: ArenaComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
