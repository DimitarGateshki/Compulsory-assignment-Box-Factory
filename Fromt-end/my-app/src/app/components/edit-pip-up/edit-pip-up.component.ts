import { Component } from '@angular/core';

@Component({
  selector: 'app-edit-pip-up',
  templateUrl: './edit-pip-up.component.html',
  styleUrls: ['./edit-pip-up.component.css']
})
export class EditPipUpComponent {

  closeEdit(){
    window.location.reload()

  }
}
