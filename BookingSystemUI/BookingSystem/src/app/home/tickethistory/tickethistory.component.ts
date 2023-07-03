import { Component } from '@angular/core';
import { ITicket } from 'src/app/models/ITicket';
import { ITicketXmlResponse } from 'src/app/models/ITicketXmlResponse';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-tickethistory',
  templateUrl: './tickethistory.component.html',
  styleUrls: ['./tickethistory.component.css']
})
export class TickethistoryComponent {

  tickets: ITicket[] = [];

  constructor(private bookingService: BookingService) { }
  ngOnInit() {
    const userString = localStorage.getItem('user');
    if (userString) {
      var user = JSON.parse(userString);
      this.bookingService.getTickets(user.id).subscribe((data) => {

        this.tickets = data;
      })
    }
  }

  getTicketTyoe(typeId: number): string {
    return TicketTypeEnum[typeId];
  }
}
