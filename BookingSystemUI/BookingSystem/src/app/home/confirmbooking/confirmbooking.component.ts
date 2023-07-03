import { Input } from '@angular/core';
import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Schedules } from 'src/app/models/Schedule';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';
import { BookingService } from '../../services/booking.service';
import { ITicket } from 'src/app/models/ITicket';
import * as xml2js from 'xml-js';
import { saveAs } from 'file-saver';
import { ITicketXmlResponse } from 'src/app/models/ITicketXmlResponse';

@Component({
  selector: 'app-confirmbooking',
  templateUrl: './confirmbooking.component.html',
  styleUrls: ['./confirmbooking.component.css']
})
export class ConfirmbookingComponent {
  submitted = false;
  form!: FormGroup;
  @Output() closeModal = new EventEmitter<string>();
  @Input() schedule: Schedules = new Schedules();
  get f() { return this.form.controls; }
  defaultDate: string = '2023-07-02';
  constructor(
    private formBuilder: FormBuilder,
    private bookingService: BookingService,
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      ticketType: [{ value: TicketTypeEnum[this.schedule.ticketType], disabled: true }, Validators.required],
      sourceId: [{ value: this.schedule.sourceName, disabled: true }, Validators.required],
      destinationId: [{ value: this.schedule.destinationName, disabled: true }, Validators.required],
      departureDate: [{ value: new Date(this.schedule.departureDate).toISOString().substring(0, 10), disabled: true }, Validators.required],
      children: [],
      adult: [],
      totalPassenger: [],
      fare: [{ value: this.schedule.fare, disabled: true }]
    });
  }

  onBookingSubmit() {
    // Logic to create a new ticket based on the form values
    // and assign it to 'ticket' property
    this.submitted = true;

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    const userString = localStorage.getItem('user');
    if (userString) {
      const user = JSON.parse(userString);
      const id = user.id;
      let payload: ITicket = {
        sourceId: this.schedule.sourceId,
        destinationId: this.schedule.destinationId,
        ticketType: this.schedule.ticketType,
        departureDate: this.schedule.departureDate,
        children: Number(this.form.value.children),
        adult: Number(this.form.value.adult),
        totalPassengers: Number(this.form.value.totalPassenger),
        userId: Number(id),
        ticketId: this.form.value.ticketId,
        returnDate: null,
        id: 0,
        sourceName: this.schedule.sourceName,
        destinationName: this.schedule.destinationName,
        username: null,
        firstName: null,
        lastName: null
      }



      this.bookingService.confirmBooking(payload)
        .subscribe((data: ITicket) => {
          const user = this.getUser();
          let ticketXmlResponse: ITicketXmlResponse = {
            TicketId: data.id,
            UserName: user.firstName + " " + user.lastName,
            Source: this.schedule.sourceName,
            Destination: this.schedule.destinationName,
            DepartureDate: this.schedule.departureDate,
            TotalPassengers: Number(this.form.value.totalPassenger),
            Children: Number(this.form.value.children),
            Adult: Number(this.form.value.adult),
          }
          const xmlData = xml2js.js2xml({ Booking: ticketXmlResponse }, { compact: true, ignoreComment: true, spaces: 4 });

          // Save XML file
          const blob = new Blob([xmlData], { type: 'text/xml' });
          saveAs(blob, 'booking.xml');
        },
          (error) => {
            console.log(error.message);
          });
    }
  }

  close() {
    this.closeModal.emit('close');
  }

  getUser() {
    const userString = localStorage.getItem('user');
    if (userString)
      return JSON.parse(userString);
  }
}
