import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(){

  }
  title = 'my-app';

  delToken: boolean =false;
  createToken: boolean =false;
  editToken: boolean =false;


  showCreate(){
    this.createToken=true;

  }

  hideCreate(){
    this.createToken=false;
  }

  showEdit(){
    this.editToken=true;
  }

  hideEdit(){
    this.editToken=false;
  }

  showDel(){
    this.delToken=true;
  }

  hideDel(){
    this.delToken=false;
  }

}
