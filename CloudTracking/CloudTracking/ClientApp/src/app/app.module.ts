import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {CustomersComponent} from './Customers/customers.component';
import { CarsComponent } from './Cars/cars.component';
import {CustomerService} from './services/customer.service';
import {CarsService} from './services/cars.service';
import {TrackingService} from './services/tracking.service';
import { TrackingComponent } from './tracking/tracking.component';
import { TrackingSearchPipe } from './tracking/tracking.search.pipe';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CustomersComponent,
    CarsComponent,
    TrackingComponent,
    TrackingSearchPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component:TrackingComponent , pathMatch: 'full' },
      { path: 'customers', component: CustomersComponent },
      { path: 'cars', component: CarsComponent },
    ])
  ],
  providers: [CustomerService,
    CarsService,
    TrackingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
