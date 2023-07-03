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
import { AdminComponent } from './admin/admin.component';
import { TickethistoryComponent } from './home/tickethistory/tickethistory.component';

import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
    AdminComponent,
    TickethistoryComponent,

  ],
  imports: [NgbModule ,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule,
    MatFormFieldModule,MatInputModule
  ],
  providers: [MatSnackBar],
  bootstrap: [AppComponent]
})
export class AppModule { }
