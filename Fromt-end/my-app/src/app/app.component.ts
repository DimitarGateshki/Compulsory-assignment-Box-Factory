import { Component } from '@angular/core';
import { BackendService } from './backend.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  boxes: any[]=[
    {name:'test'},
    {name:'test1'},
    {name:'test2'},
    {name:'albert'},

  ];
  delToken: boolean =false;
  editToken: boolean =false;
  title = 'my-app';

  searchText='';

  createToken: boolean =false;

  constructor(
    private backendService: BackendService,
    private http:HttpClientModule){

  }



  ngOnInit(): void {
    this.backendService.gatAllBoxes().subscribe(data =>{
      this.boxes=data.responseData;
      console.log(data);
    })

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
    const all = document.getElementById('all');



    if(type==0){
      if(sale && sold && all){
        all.classList.add('selected-cat');
        sale.classList.remove('selected-cat');
        sold.classList.remove('selected-cat');
        this.backendService.gatAllBoxes().subscribe(data =>{
          this.boxes=data.responseData;
          console.log(data);
        })

        }

    }else if(type==1){

      if(sale && sold && all){
      sale.classList.add('selected-cat');
      sold.classList.remove('selected-cat');
      all.classList.remove('selected-cat');

      this.backendService.gatAllBoxes().subscribe(data =>{
        this.boxes=data.responseData.filter((e:any)=>e.category=='for sale');
        console.log(data);
      })

      }

    }else{

      if(sale && sold && all){
        sale.classList.remove('selected-cat');
        sold.classList.add('selected-cat');
        all.classList.remove('selected-cat');


        this.backendService.gatAllBoxes().subscribe(data =>{
          this.boxes=data.responseData.filter((e:any)=>e.category=='sold');
          console.log(data);
        })
        }
    }
  }

  sort(){
    console.log(this.boxes)

    this.boxes=this.boxes.sort((a, b) => (a.name < b.name ? -1 : 1))
    console.log(this.boxes)
  }

  search(){
   this.boxes= this.boxes.filter(e=>e.name.includes(this.searchText));
    console.log(this.searchText);
  if(this.searchText==""){
    this.backendService.gatAllBoxes().subscribe(data =>{
      this.boxes=data.responseData;
      console.log(data);
    })
  }
  }
}
