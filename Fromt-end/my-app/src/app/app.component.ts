import { Component } from '@angular/core';
import { BackendService } from './backend.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  boxes: any[]=[1,2,3,4,5,6,7,8];

  constructor(
    private backendService: BackendService,
  ){

  }
  title = 'my-app';

  createToken: boolean =false;


  ngOnInit(): void {
    this.backendService.gatAllBoxes().subscribe(data=>{
      console.log(data);
    })

  }
  showCreate(){
    this.createToken=true;

  }

  hideCreate(){
    this.createToken=false;
  }



}
