import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend.service';

@Component({
  selector: 'app-del-pop-up',
  templateUrl: './del-pop-up.component.html',
  styleUrls: ['./del-pop-up.component.css']
})
export class DelPopUpComponent {
  id: number=Number(localStorage.getItem("id"));


   constructor(
    private backendService: BackendService,
  ){}

  delete(){
    this.backendService.removeBoxByID(this.id).subscribe(e=>{
      console.log(e);
    })

   this.closeDel();
  }

  closeDel(){
    localStorage.removeItem("id");

    window.location.reload()

  }
}
