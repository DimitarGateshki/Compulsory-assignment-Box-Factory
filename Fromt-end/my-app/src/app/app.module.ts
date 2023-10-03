import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreatePopUpComponent } from './components/create-pop-up/create-pop-up.component';
import { DelPipUpComponent } from './components/del-pip-up/del-pip-up.component';
import { BoxComponentComponent } from './components/box-component/box-component.component';
import { EditPipUpComponent } from './components/edit-pip-up/edit-pip-up.component';

@NgModule({
  declarations: [
    AppComponent,
    CreatePopUpComponent,
    EditPipUpComponent,
    DelPipUpComponent,
    BoxComponentComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
