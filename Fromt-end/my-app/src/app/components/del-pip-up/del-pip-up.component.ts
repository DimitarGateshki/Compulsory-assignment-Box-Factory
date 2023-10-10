import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend.service';

@Component({
  selector: 'app-del-pip-up',
  templateUrl: './del-pip-up.component.html',
  styleUrls: ['./del-pip-up.component.css']
})
export class DelPipUpComponent {
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
