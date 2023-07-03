import { Bus } from "./Bus";
import { Plane } from "./Plane";
import { TicketTypeEnum } from "./TicketTypeEnum";
import { Train } from "./Train";

export class Schedules {
  id!: number;
  ticketType!: TicketTypeEnum;
  arrivalTime!: string;
  departureTime!: string;
  journeyTime!: number;
  stops!: number;
  busDto!: Bus;
  trainDto!: Train;
  planeDto!: Plane;
  sourceId!: number;
  destinationId!: number;
  sourceName!: string;
  destinationName!: string;
  departureDate!: Date;
  fare!: number;
}
