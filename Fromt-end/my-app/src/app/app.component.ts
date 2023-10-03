import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  boxes: any[]=[1,2,3,4,5,6,7,8];

  constructor(){

  }
  title = 'my-app';

  createToken: boolean =false;


  showCreate(){
    this.createToken=true;

  }

  hideCreate(){
    this.createToken=false;
  }



}
