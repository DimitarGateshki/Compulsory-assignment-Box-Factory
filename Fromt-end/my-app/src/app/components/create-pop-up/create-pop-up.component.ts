import { Component } from '@angular/core';

@Component({
  selector: 'app-create-pop-up',
  templateUrl: './create-pop-up.component.html',
  styleUrls: ['./create-pop-up.component.css']
})
export class CreatePopUpComponent {


  closeCreate(){
    window.location.reload()

  }
  closeEdit(){
    window.location.reload()

  }
  closeDel(){
    window.location.reload()

  }

}
