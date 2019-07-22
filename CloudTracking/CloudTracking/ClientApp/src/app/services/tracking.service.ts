import { Injectable, EventEmitter } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { Tracking } from '../Models/Tracking';
@Injectable()
export class TrackingService {
  private hubConnection: signalR.HubConnection;
  public StatusUpdated: EventEmitter<Tracking> = new EventEmitter(); 
  public StatusLoaded: EventEmitter<Tracking[]> = new EventEmitter();
  constructor() { 
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('/trackinghub')
    .build();

  this.hubConnection
    .start()
    .then(() =>{ 
   this.getStatus();
  }
    )
    .catch(err => console.log('Error while starting connection: ' + err))
  this.hubConnection.on('statusUpdated', (status) => {
    
    this.StatusUpdated.emit(status);
   
  });
  this.hubConnection.on('statusLoaded', (data) => {
    
    this.StatusLoaded.emit(data);
  });

  }
  getStatus()
  {
    this.hubConnection
    .invoke('getStatus')
  }

}
