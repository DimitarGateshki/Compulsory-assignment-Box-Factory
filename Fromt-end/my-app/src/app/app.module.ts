import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreatePopUpComponent } from './components/create-pop-up/create-pop-up.component';
import { DelPipUpComponent } from './components/del-pip-up/del-pip-up.component';
import { EditPipUpComponent } from './components/edit-pip-up/edit-pip-up.component';
import { HttpClientModule } from '@angular/common/http';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, NgForm } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    CreatePopUpComponent,
    EditPipUpComponent,
    DelPipUpComponent,

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
