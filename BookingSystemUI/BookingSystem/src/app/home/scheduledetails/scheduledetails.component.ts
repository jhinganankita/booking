import { Component, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Schedules } from 'src/app/models/Schedule';
import { ConfirmbookingComponent } from '../confirmbooking/confirmbooking.component';


@Component({
  selector: 'app-scheduledetails',
  templateUrl: './scheduledetails.component.html',
  styleUrls: ['./scheduledetails.component.css']
})
export class ScheduledetailsComponent {

 @Input() schedules: Schedules[] = [];

 constructor(private modalService: NgbModal) {}

 confirmBooking() {
  const modalRef = this.modalService.open(ConfirmbookingComponent);
  // Additional configuration or data passing to the modal can be done here
}
}
