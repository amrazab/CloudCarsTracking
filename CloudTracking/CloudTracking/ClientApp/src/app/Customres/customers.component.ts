import { Component,OnInit } from '@angular/core';
import{Customer} from '../Models/Customer'

@Component({
  selector: 'customers',
  templateUrl: './customers.component.html',
})
export class CustomersComponent implements OnInit {
  ngOnInit() {
   this.customers=[
     {
       Id:"c1",
       Name:"amr",
       Address:"alex"
     },
     {
      Id:"c2",
      Name:"ali",
      Address:"cairo"
    }
   ]
  }
  customers:Customer[];
  title:string ="Customers List";
  constructor()
  {
   this.setTitle("Customers")
  }
  setTitle(title:string):void{
    this.title = title;
  }
}
