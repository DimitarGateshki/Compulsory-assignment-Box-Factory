import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend.service';

@Component({
  selector: 'app-create-pop-up',
  templateUrl: './create-pop-up.component.html',
  styleUrls: ['./create-pop-up.component.css']
})
export class CreatePopUpComponent {

  name: string="";
  categoryCheck:boolean=false;
  category: string="";
   regex : RegExp = /^[a-zA-Z ]{2,30}$/;

  constructor(
    private backendService: BackendService,
  ){}



  setInput(){
    if(this.regex.test(this.name) && this.name!='Incorrect name'){
    this.category= this.categoryCheck ? "for sale"  : 'sold';

    this.backendService.createBox(this.name, this.category).subscribe(e=>{
      console.log(e);
    })



    this.closeCreate();

  }else{
    this.name='Incorrect name';
  }

  }

  closeCreate(){
    window.location.reload()

  }



}
