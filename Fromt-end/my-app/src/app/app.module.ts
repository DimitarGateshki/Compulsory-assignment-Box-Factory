import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreatePopUpComponent } from './components/create-pop-up/create-pop-up.component';
import { DelPipUpComponent } from './components/del-pip-up/del-pip-up.component';
import { EditPipUpComponent } from './components/edit-pip-up/edit-pip-up.component';
<<<<<<< Updated upstream
=======
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, NgForm } from '@angular/forms';

>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AppComponent,
    CreatePopUpComponent,
    EditPipUpComponent,
    DelPipUpComponent,

  ],
  imports: [
<<<<<<< Updated upstream
    BrowserModule
=======
    BrowserModule,
    HttpClientModule,

    FormsModule,


>>>>>>> Stashed changes
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
