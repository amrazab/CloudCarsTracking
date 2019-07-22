import { Component,OnInit } from '@angular/core';
import{Customer} from '../Models/Customer'
import {CustomerService} from '../services/customer.service';

@Component({
  selector: 'customers',
  templateUrl: './customers.component.html',
})
export class CustomersComponent implements OnInit {
  ngOnInit() {
    this.customerService.Updated.subscribe(customer=>console.log(customer.name));
   this.customerService.loadCustomers().subscribe(data => {
  this.customers=data;
  
});
  }
  customers:Customer[];
  title:string ="Customers List";
  constructor(private customerService:CustomerService)
  {
   this.setTitle("Customers..")
  }
  setTitle(title:string):void{
    this.title = title;
  }
}
