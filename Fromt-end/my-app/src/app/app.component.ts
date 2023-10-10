import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  boxes: any[]=[1,2,3,4,5,6,7,8];
  delToken: boolean =false;
  editToken: boolean =false;
  title = 'my-app';

  createToken: boolean =false;

  constructor(){

  }




  ngOnInit(): void {
    //this.backendService.gatAllBoxes().subscribe(data =>{
      //console.log(data);
   // })

  }
  showCreate(){
    this.createToken=true;

  }

  hideCreate(){
    this.createToken=false;
  }

  showEdit(id: any){
    localStorage.setItem("id", id);
    this.editToken=true;
  }



  showDel(id: any){
    localStorage.setItem("id", id);
    this.delToken=true;
  }



  selectCat(type: number){
    const sale = document.getElementById('sale');
    const sold = document.getElementById('sold');


    if(type==1){

      if(sale && sold){
      sale.classList.add('selected-cat');
      sold.classList.remove('selected-cat');

      }

    }else{

      if(sale && sold){
        sale.classList.remove('selected-cat');
        sold.classList.add('selected-cat');

        }
    }
  }

  sort(){

  }

}
