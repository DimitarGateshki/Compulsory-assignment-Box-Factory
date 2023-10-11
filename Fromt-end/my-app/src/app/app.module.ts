import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreatePopUpComponent } from './components/create-pop-up/create-pop-up.component';
import { DelPopUpComponent } from './components/del-pop-up/del-pop-up.component';
import { EditPopUpComponent } from './components/edit-pop-up/edit-pop-up.component';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule, NgForm } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    CreatePopUpComponent,
    EditPopUpComponent,
    DelPopUpComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
