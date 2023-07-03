import { Injectable } from '@angular/core';
import { environment } from './../environments/environment';

import { HttpClient } from "@angular/common/http";
import { ITicketType } from "../models/ITicketType";
import { TicketTypeEnum } from "../models/TicketTypeEnum";
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { ILocation } from '../models/ILocation';
import { ITicket } from '../models/ITicket';
import { IScheduleRequest } from '../models/IScheduleRequest';
import { Schedules } from '../models/Schedule';
import {DataTablesResponse} from '../models/DataTablesResponse'

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private ticketTypes: ITicketType[] = [];

  private ticketType!:ITicketType;

  baseURL= environment.baseUrl;
  constructor(
    private httpClient: HttpClient
    ) { }


    getTicketTypes() : Observable<ITicketType[]>  {
      console.log('baseurl: '+this.baseURL);
     return this.httpClient.get<ITicketType[]>(`${this.baseURL}tickettypes`);
    }

    getLocations() : Observable<ILocation[]>  {
      console.log('baseurl: '+this.baseURL);
     return this.httpClient.get<ILocation[]>(`${this.baseURL}locations`);
    }

    searchBookings(scheduleRequest: IScheduleRequest): Observable<Schedules[]> {
      return this.httpClient.post<Schedules[]>(`${this.baseURL}schedules`, scheduleRequest);
    }

    confirmBooking(ticket: ITicket): Observable<ITicket> {
      return this.httpClient.post<ITicket>(`${this.baseURL}tickets`, ticket);
    }

    getTickets(userId: number): Observable<ITicket[]>{

      return this.httpClient.get<ITicket[]>(`${this.baseURL}tickets?userId=${userId}`);
    }

    getUserTickets(): Observable<ITicket[]>{

      return this.httpClient.get<ITicket[]>(`${this.baseURL}admintickets`);
    }
}




