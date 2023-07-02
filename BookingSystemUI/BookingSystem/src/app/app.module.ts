import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookingComponent } from './home/booking/booking.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { MainNavComponent } from './home/main-nav/main-nav.component';
import { AlertComponent } from './alert/alert.component';
import { ScheduledetailsComponent } from './home/scheduledetails/scheduledetails.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmbookingComponent } from './home/confirmbooking/confirmbooking.component';

//import { LoginComponent } from './account/login/login.component';
//import { RegisterComponent } from './account/register/register.component';

const routes: Routes = [
  { path: "", redirectTo: "booking", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "booking", component: BookingComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    BookingComponent,
    HomeComponent,
    MainNavComponent,
    AlertComponent,
    ScheduledetailsComponent,
    ConfirmbookingComponent,

  ],
  imports: [NgbModule ,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
