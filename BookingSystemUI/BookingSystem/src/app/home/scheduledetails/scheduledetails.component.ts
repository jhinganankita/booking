import { Component, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Schedules } from 'src/app/models/Schedule';
import { ConfirmbookingComponent } from '../confirmbooking/confirmbooking.component';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';

@Component({
  selector: 'app-scheduledetails',
  templateUrl: './scheduledetails.component.html',
  styleUrls: ['./scheduledetails.component.css']
})
export class ScheduledetailsComponent {

 @Input() schedules: Schedules[] = [];

 constructor(private modalService: NgbModal) {}

 confirmBooking(scheduleId: number) {
  let selectedSchedule = this.schedules.find(x=>x.id== scheduleId);
  const confirmBookingModalRef = this.modalService.open(ConfirmbookingComponent);
    confirmBookingModalRef.componentInstance.schedule = selectedSchedule;
    confirmBookingModalRef.componentInstance.closeModal.subscribe(($e:any) => {
      confirmBookingModalRef.close();
    })
  }

  getTicketTyoe(typeId: number): string {
    return TicketTypeEnum[typeId];
  }
}
