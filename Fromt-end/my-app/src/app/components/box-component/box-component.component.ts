import { Component } from '@angular/core';

@Component({
  selector: 'app-box-component',
  templateUrl: './box-component.component.html',
  styleUrls: ['./box-component.component.css']
})
export class BoxComponentComponent {

  delToken: boolean =false;
  editToken: boolean =false;


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
