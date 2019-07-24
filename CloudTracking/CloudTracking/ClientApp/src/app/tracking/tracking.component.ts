import { Component, OnInit } from '@angular/core';
import {Tracking} from '../Models/Tracking';
import {TrackingService} from '../services/tracking.service';

@Component({
  selector: 'app-tracking',
  templateUrl: './tracking.component.html',
  styleUrls: ['./tracking.component.css']
})
export class TrackingComponent implements OnInit {
  statusList:Tracking[];
  customers:string[];
  customerSerch:string="";
  statusSearch:number=0;
  constructor(private trackingService:TrackingService ) {


   }

  ngOnInit() {
    this.trackingService.getStatus();
    this.trackingService.StatusLoaded.subscribe(

      (data:Tracking[])=>{
        this.statusList=data;
        this.fillCustomers();
      }
    );
    this.trackingService.StatusUpdated.subscribe(
      (      item: Tracking)=>
      {
        if(this.statusList==null || this.statusList==undefined)
        {
          this.statusList=[];
        }
        var currentCar = this.statusList.filter(s=> s.carId==item.carId);
        if(currentCar.length==0){
        this.statusList.push(item)
        }else{
          currentCar[0].carStatus = item.carStatus;
          currentCar[0].oilLevel = item.oilLevel;
          currentCar[0].errorMessage = item.errorMessage;
          currentCar[0].time = item.time;
        }
      
      }
      );
  }
  fillCustomers() {
    if(this.customers==null || this.customers==undefined)
    {
      this.customers=[];
    }
    var customers = this.statusList.map(function(item) { return item.customerId; });
    this.customers = customers.filter(function(v,i) { return customers.indexOf(v) == i; });
  }
  isfiltered():boolean
  {
    return false;
  }

}
