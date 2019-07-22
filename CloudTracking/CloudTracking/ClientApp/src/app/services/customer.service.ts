import { Injectable, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Customer} from '../Models/Customer';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable()
export class CustomerService {
  public Updated: EventEmitter<Customer> = new EventEmitter();
  constructor(private http:HttpClient) { 

   
  }
  loadCustomers()
  {
   // this.Updated.emit({id:"tst",name:"tst",address:"alex"});
    return this.http.get<Customer[]>("/api/Customers");
  
  }

}
