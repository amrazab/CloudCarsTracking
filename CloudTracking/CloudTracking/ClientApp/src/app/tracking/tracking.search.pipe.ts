import { Pipe, PipeTransform } from '@angular/core';
import { Tracking } from '../Models/Tracking';
import { stat } from 'fs';
 
@Pipe({
    name: 'TrackingSearch'
  })
export class TrackingSearchPipe implements PipeTransform {
  transform(tracking: Tracking[], customer: string,status:number) {
    return tracking.filter(t => (customer==""  || t.customerId==customer)
    &&(status==0 || t.carStatus==status)
    );
  }
}