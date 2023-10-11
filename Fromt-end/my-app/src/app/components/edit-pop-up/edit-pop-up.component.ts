import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend.service';

@Component({
  selector: 'app-edit-pop-up',
  templateUrl: './edit-pop-up.component.html',
  styleUrls: ['./edit-pop-up.component.css']
})
export class EditPopUpComponent {
  name: string="";
  categoryCheck:boolean=false;
  category: string="";
   regex : RegExp = /^[a-zA-Z ]{2,30}$/;
   id: number=Number(localStorage.getItem("id"));


   constructor(
    private backendService: BackendService,
  ){}



  setInput(){
    if(this.regex.test(this.name) && this.name!='Incorrect name'){
    this.category= this.categoryCheck ? "for sale"  : 'sold';

    this.backendService.editBoxByID(this.id,this.name,this.category).subscribe(e=>{
      console.log(e);
    })



    this.closeEdit();

  }else{
    this.name='Incorrect name';
  }

  }


  closeEdit(){
    localStorage.removeItem("id");
    window.location.reload()

  }
}
