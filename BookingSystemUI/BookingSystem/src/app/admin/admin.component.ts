import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { TicketTypeEnum } from 'src/app/models/TicketTypeEnum';
import { BookingService } from 'src/app/services/booking.service';
import { ITicket } from 'src/app/models/ITicket';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';
import * as JSZip from 'jszip';
import { ITicketXmlResponse } from 'src/app/models/ITicketXmlResponse';
import * as xml2js from 'xml-js';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  tickets: ITicket[] = [];
  userIdList: number[] = [];

  displayedColumns: string[] = [ 'username', 'firstName', 'lastName',
  'ticketTypeName', 'sourceName', 'destinationName','departureDate','totalPassengers','adult','children' ];
  dataSource = new MatTableDataSource<ITicket>();
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  sortedData!: ITicket[];

  constructor(private bookingService: BookingService, private http: HttpClient) { }
  ngOnInit() {
      this.bookingService.getUserTickets().subscribe((data) => {

        this.tickets = data;
        this.dataSource.data = data;
      })
    }


  getTicketType(typeId: number): string {
    return TicketTypeEnum[typeId];
  }

  doFilter = (val: string) => {
    this.dataSource.filter = val.trim().toLocaleLowerCase();
  }

  // generateTicketsZip() {
  //   const url = 'YOUR_API_ENDPOINT/generate-tickets-xml';

  //   this.http.get(url, { responseType: 'text' })
  //     .subscribe((response: string) => {
  //       this.createZip(response);
  //   });
  // }

  createZip() {
    const zip: JSZip = new JSZip();
    this.userIdList = this.tickets.filter(ticket => ticket.userId !== null)
    .map(ticket => ticket.userId as number);
    this.userIdList = Array.from(new Set(this.userIdList));

    // Create separate folders for each user
    this.userIdList.forEach(userId => {
      const folderName = `user_${userId}`;
      const ticketList:ITicket[] = this.tickets.filter(ticket => ticket.userId !== null
        && ticket.userId == userId);

        //create 
        ticketList.forEach(ticket => {
          const xmlFileName = `ticket_${ticket.id}.xml`;
          const userXmlFileName = `${xmlFileName}`;
          const xmlData = this.generateXmlData(ticket);

          // Add the XML file to the corresponding user's folder
          const userFolder: JSZip | null = zip.folder(folderName) || null;
          if (userFolder) {
            userFolder.file(userXmlFileName, xmlData);
          } else {
            console.error(`Failed to create folder ${folderName}`);
          }
          zip.folder(folderName)?.file(userXmlFileName, xmlData);
        });

    });

    // Generate the combined ZIP file
    zip.generateAsync({ type: 'blob' })
      .then((content) => {
        saveAs(content, 'tickets.zip');
      });
  }

  generateXmlData(ticket: ITicket){
      let ticketXmlResponse = {
      TicketId: ticket.id,
      UserName: ticket.firstName + " " + ticket.lastName,
      Source: ticket.sourceName,
      Destination: ticket.destinationName,
      DepartureDate: ticket.departureDate,
      TotalPassengers: Number(ticket.totalPassengers),
      Children: Number(ticket.children),
      Adult: Number(ticket.adult),
    }
    const xmlData = xml2js.js2xml({ Booking: ticketXmlResponse }, { compact: true, ignoreComment: true, spaces: 4 });
    return xmlData;
  }
}
