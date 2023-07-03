import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import {DataTablesResponse} from '../models/DataTablesResponse';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';
import { BookingService } from 'src/app/services/booking.service';
import { ITicket } from 'src/app/models/ITicket';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  tickets: ITicket[] = [];

  constructor(private bookingService: BookingService) { }
  ngOnInit() {    
      this.bookingService.getUserTickets().subscribe((data) => {

        this.tickets = data;
      })
    }
  

  getTicketTyoe(typeId: number): string {
    return TicketTypeEnum[typeId];
  }
}
