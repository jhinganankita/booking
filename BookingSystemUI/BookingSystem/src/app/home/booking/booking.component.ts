import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AlertService } from '../../services/alert.service';
import { BookingService } from '../../services/booking.service';
import { ITicketType } from '../../models/ITicketType';
import { ITicket } from '../../models/ITicket';
import { ILocation } from '../../models/ILocation';
import { locationValidator } from '../../validators/location.validator';
import { IScheduleRequest } from 'src/app/models/IScheduleRequest';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';
import { Schedules } from 'src/app/models/Schedule';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent {
  form!: FormGroup;
  loading = false;
  submitted = false;
  schedules: Schedules[] = [];
  constructor(
    private bookingService: BookingService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private alertService: AlertService
  ) { }

  get f() { return this.form.controls; }

  ticketTypes: ITicketType[] = [];
  locations: ILocation[] = [];
  selected = null;

  ngOnInit() {
    this.form = this.formBuilder.group({
      ticketType: ['', Validators.required],
      sourceId: [null, Validators.required],
      destinationId: ['', Validators.required],
      departureDate: ['',Validators.required]
    }, {
      validator: locationValidator
    });

    this.bookingService.getTicketTypes().subscribe((data) => {
      this.ticketTypes = data;
    },
      (error) => {
        console.log(error.message);
      });

    this.bookingService.getLocations().subscribe((data) => {
      this.locations = data;
    },
      (error) => {
        console.log(error.message);
      });


  }

  onSearchSubmit() {
    // Logic to create a new ticket based on the form values
    // and assign it to 'ticket' property
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    let payload: IScheduleRequest = {
      sourceId: this.form.value.sourceId,
      destinationId: this.form.value.destinationId,
      ticketType: Number(this.form.value.ticketType),
      departureDate: new Date(this.form.value.departureDate)
    }
    this.bookingService.searchBookings(payload)
      .subscribe((data) => {
        this.schedules = data;
        this.loading = false;
      },
        (error) => {
          console.log(error.message);
        });

  }
}
